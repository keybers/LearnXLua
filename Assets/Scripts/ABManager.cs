
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 知识点
/// 1.AB包相关的api
/// 2.单例模式
/// 3.委托-》lambd表达式
/// 4.协程
/// 5.字典
/// </summary>

public class ABManager : SingletonAutoMono<ABManager>
{
    //ab包管理器：让外部更方便的进行资源加载
    //用字典来存储 加载过的AB包
    private Dictionary<string, AssetBundle> abDic = new Dictionary<string, AssetBundle>();

    //主包,ab包不能重复加载，否则会出错
    private AssetBundle abMain = null;

    //依赖包配置文件
    private AssetBundleManifest abManiFest = null;

    /// <summary>
    /// ab包存放路径，方便修改
    /// </summary>
    private string PathURL
    {
        get
        {
            return Application.streamingAssetsPath + "/";
        }
    }

    /// <summary>
    /// 主包名 方便修改
    /// </summary>
    private string MainABName
    {
        get
        {
#if UNITY_IOS
            return "IOS"
#elif UNITY_ANDROID
            return "Android";
#else
            return "PC";
#endif
        }
    }
    /// <summary>
    /// 加载AB包的方法
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    private void loadRes(string abName)
    {
        AssetBundle ab = null;
        //加载AB主包
        if (abMain == null)
        {
            //最终打包后的路径可能不是streamingAssets文件下
            abMain = AssetBundle.LoadFromFile(PathURL + MainABName);
            abManiFest = abMain.LoadAsset<AssetBundleManifest>("AssetBundleManifest");//获取主包配置文件
        }

        //获取依赖包的信息，加载主包
        string[] strs = abManiFest.GetAllDependencies(abName);
        for (int i = 0; i < strs.Length; i++)
        {
            //判断包是否加载过
            if (!abDic.ContainsKey(strs[i]))
            {
                //加载
                ab = AssetBundle.LoadFromFile(PathURL + strs[i]);
                abDic.Add(strs[i], ab);
            }
        }

        //如果没有,加载资源包的关键配置文件，获取资源包
        if (!abDic.ContainsKey(abName))
        {
            ab = AssetBundle.LoadFromFile(PathURL + abName);
            abDic.Add(abName, ab);
        }
    }

    //同步加载
    public object LoadRes(string abName,string resName)
    {
        //加载AB包
        loadRes(abName);
        //加载依赖包
        object obj = abDic[abName].LoadAsset(resName);
        if(obj is GameObject)
        {
            return Instantiate(obj as GameObject);
        }
        else
        {
            return obj;
        }

    }
    //异步加载的方法,lua不支持泛型
    public UnityEngine.Object LoadRes(string abName,string resName,Type type)
    {
        //加载AB包
        loadRes(abName);
        //加载依赖包
        UnityEngine.Object obj = abDic[abName].LoadAsset(resName , type);//这样可以避免相同文件名，不同类型的资源加载
        if (obj is GameObject)
        {
            return Instantiate(obj);
        }
        else
        {
            return obj;
        }
    }
    /// <summary>
    /// 加载AB包中的文件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName">ab包名</param>
    /// <param name="resName">文件名</param>
    /// <returns></returns>
    public T LoadRes<T>(string abName,string resName) where T : UnityEngine.Object
    {
        //同步加载，根据泛型加载
        //加载AB包
        loadRes(abName);
        //加载依赖包
        T obj = abDic[abName].LoadAsset<T>(resName);//这样可以避免相同文件名，不同类型的资源加载
        if (obj is GameObject)
        {
            return Instantiate(obj);
        }
        else
        {
            return obj;
        }
    }
    //异步加载的方法
    //ab包没有使用异步加载
    //知识从ab包中 加载逻辑 使用异步
    //根据名字异步加载
    public void LoadResAsync(string abName,string resName,UnityAction<object> callback)
    {
        StartCoroutine(ReallyLoadResAsync(abName, resName, callback));
    }

    private IEnumerator ReallyLoadResAsync(string abName, string resName, UnityAction<object> callback)
    {
        loadRes(abName);
        //加载依赖包
        AssetBundleRequest assetBundleRequest = abDic[abName].LoadAssetAsync(resName);
        yield return assetBundleRequest;

        //异步加载结束后，通过委托 传递给外部来使用
        if (assetBundleRequest.asset is GameObject)
        {
            callback(Instantiate(assetBundleRequest.asset));
        }
        else
        {
            callback(assetBundleRequest.asset);
        }
    }

    //根据type异步加载
    public void LoadResAsync(string abName, string resName, Type type, UnityAction<object> callback)
    {
        StartCoroutine(ReallyLoadResAsync(abName, resName, type, callback));
    }

    private IEnumerator ReallyLoadResAsync(string abName, string resName, Type type, UnityAction<object> callback)
    {
        loadRes(abName);
        //加载依赖包
        AssetBundleRequest assetBundleRequest = abDic[abName].LoadAssetAsync(resName, type);
        yield return assetBundleRequest;

        //异步加载结束后，通过委托 传递给外部来使用
        if (assetBundleRequest.asset is GameObject)
        {
            callback(Instantiate(assetBundleRequest.asset));
        }
        else
        {
            callback(assetBundleRequest.asset);
        }
    }

    //根据泛型异步加载
    public void LoadResAsync<T>(string abName, string resName, UnityAction<T> callback) where T : UnityEngine.Object
    {
        StartCoroutine(ReallyLoadResAsync<T>(abName, resName, callback));
    }

    private IEnumerator ReallyLoadResAsync<T>(string abName, string resName, UnityAction<T> callback) where T : UnityEngine.Object
    {
        loadRes(abName);
        //加载依赖包
        AssetBundleRequest assetBundleRequest = abDic[abName].LoadAssetAsync<T>(resName);
        yield return assetBundleRequest;

        //异步加载结束后，通过委托 传递给外部来使用
        if (assetBundleRequest.asset is GameObject)
        {
            callback(Instantiate(assetBundleRequest.asset) as T);
        }
        else
        {
            callback(assetBundleRequest.asset as T);
        }
    }

    //单个包卸载
    public void UnLoad(string abName)
    {
        if (abDic.ContainsKey(abName))
        {
            abDic[abName].Unload(false);
            abDic.Remove(abName);
        }
    }
    //所有包的卸载
    public void ClearAB()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        abDic.Clear();
        abMain = null;
        abManiFest = null;
    }
}
