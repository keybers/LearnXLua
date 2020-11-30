using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallLuaTable_lesson9 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        //不建议使用LuaTable和LuaFunction 效率低 垃圾多
        //都是引用类型
        LuaTable luaTable = LuaManager.GetInstance().Global.GetInPath<LuaTable>("testTable");

        Debug.Log("testInt:" + luaTable.GetInPath<int>("testInt"));
        Debug.Log("testBool:" + luaTable.GetInPath<bool>("testBool"));
        Debug.Log("testString:" + luaTable.GetInPath<string>("testString"));
        Debug.Log("testFloat:" + luaTable.GetInPath<float>("testFloat"));

        luaTable.GetInPath<LuaFunction>("testFun").Call();
        //改  是引用拷贝
        luaTable.Set("testInt", 55);
        Debug.Log(luaTable.GetInPath<int>("testInt"));
        
        LuaTable luaTable2 = LuaManager.GetInstance().Global.GetInPath<LuaTable>("testTable");
        Debug.Log(luaTable2.GetInPath<int>("testInt"));

        //table不用了 一定要销毁
        //luaTable.Dispose();
        //LuaManager.GetInstance().Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
