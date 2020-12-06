using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

/// <summary>
/// Lua管理器
/// 提供 Lua管理器
/// 保证解析器的唯一性
/// </summary>
public class LuaManager : BaseManager<LuaManager>
{
    //Lua脚本会放在AB包
    //最终我们会通过加载AB包再加载其中的Lua脚本资源 来执行它
    //AB如果要加载文本 后缀还是要有一定的限制 .Lua不能被识别
    //打包之前要把Lua文件后缀改为TXT
    //Lua解析器:释放垃圾，销毁，重定向
    private LuaEnv luaEnv;

    //属性Global：得到Lua当中的_G
    public LuaTable Global
    {
        get
        {
            return luaEnv.Global;
        }
    }

    public void Init()
    {
        if(luaEnv != null)
        {
            return;
        }

        luaEnv = new LuaEnv();
        //加载Lua脚本 重定向
        
        luaEnv.AddLoader((ref string filepath) =>
        {
            string path = Application.dataPath + "/Lua/" + filepath + ".lua";
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                Debug.LogError("文件不存在");
            }
            return null;
        });

        //加载AB包的Lua脚本 重定向
        luaEnv.AddLoader((ref string filepath) =>
        {
            //Debug.Log("进入AB包重定向加载");
            ////从AB包中加载lua文件
            ////加载AB包
            //string path = Application.streamingAssetsPath + "/lua";
            //AssetBundle assetBundle = AssetBundle.LoadFromFile(path);

            ////加载Lua文件 返回 filepath + ".lua"是文件名
            //TextAsset tx = assetBundle.LoadAsset<TextAsset>(filepath + ".lua");
            ////加载lua文件 byte数组
            //return tx.bytes;
            //=====================================================================
            //通过AB包管理器加载的Lua脚本资源
            TextAsset lua = ABManager.GetInstance().LoadRes<TextAsset>("lua", filepath + ".lua");
            if(lua != null)
            {
                return lua.bytes;
            }
            else
            {
                Debug.LogError("重定向失败，文件名为:" + filepath);
            }
            return null;
        });
    }

    /// <summary>
    /// 执行Lua语言
    /// </summary>
    /// <param name="str"></param>
    public void DoString(string str)
    {
        luaEnv.DoString(str);
    }

    /// <summary>
    /// 释放Lua垃圾
    /// </summary>
    public void Tick()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器初始化");
            return;
        }

        luaEnv.Tick();
    }

    /// <summary>
    /// 销毁解析器并滞空
    /// </summary>
    public void Dispose()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器初始化");
            return;
        }
        luaEnv.Dispose();
        luaEnv = null;
    }

    /// <summary>
    /// DoString操作，只需要传入文件名
    /// </summary>
    /// <param name="filePath">Lua文件名,无后缀</param>
    public void DoLuaFile(string filePath)
    {
        string str = string.Format("require('{0}')", filePath);
        DoString(str);
    }
}
