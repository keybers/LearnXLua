using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEngine;
using XLua;

public class Loader_lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaEnv luaEnv = new LuaEnv();

        //xlua提供的一个路径重定向的方法
        //允许我们自定义 加载 lua脚本
        //当我们执行lua语言 require时 相当于执行lua 脚本
        //它就会执行 我们自定义传入的这个函数
        luaEnv.AddLoader((ref string filePath) =>
        {
            //传入的参数是require执行的lua文件名
            //拼接一个lua路径
            string path = Application.dataPath + "/Lua/" + filePath + ".lua";
            Debug.Log(path);
            //通过函数中的逻辑 去加载 Lua文件
            //有路径 就去加载文件
            //file知识点 C#提供文件读写的类
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                Debug.Log("MyCustomLoader重定向失败:" + path);
            }

            return null;
        });
        //最终我们会去AB包中去加载Lua文件


        //首先在自定义函数中找文件，因为是委托，所以会从委托事件中一个一个查找，如果没找到则会在默认路径Resources中寻找
        luaEnv.DoString("require('Main')");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //自动执行
    private byte[] MyCustomLoader(ref string filePath)
    {
        //传入的参数是require执行的lua文件名
        //拼接一个lua路径
        string path = Application.dataPath + "/Lua/" + filePath + ".lua";
        Debug.Log(path);
        //通过函数中的逻辑 去加载 Lua文件
        //有路径 就去加载文件
        //file知识点 C#提供文件读写的类
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("MyCustomLoader重定向失败:" + path);
        }

        return null;
    }      
}
