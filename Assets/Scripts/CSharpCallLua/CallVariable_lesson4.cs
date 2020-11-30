using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallVariable_lesson4 : MonoBehaviour
{
    void Start()
    {
        //初始化解析器
        LuaManager.GetInstance().Init();

        //Lua重定向
        LuaManager.GetInstance().DoLuaFile("Main");

        //使用lua解析器中的global属性，也就是_G表
        //int i = LuaManager.GetInstance().Global.Get<int>("testNumber");
        //Debug.Log("testNumber:" + i);弃用了
        int i = LuaManager.GetInstance().Global.GetInPath<int>("testNumber");
        Debug.Log("testNumber:" + i);

        i = 10;

        //改值用Set
        LuaManager.GetInstance().Global.Set("testNumber", 55);

        //值拷贝 不会影响原来lua中的值
        i = LuaManager.GetInstance().Global.GetInPath<int>("testNumber");
        Debug.Log("testNumber:" + i);
        //=================================================================

        double f = LuaManager.GetInstance().Global.GetInPath<double>("testFloat");
        Debug.Log("testFloat:" + f);

        float w = LuaManager.GetInstance().Global.GetInPath<float>("testFloat");
        Debug.Log("testFloat:" + w);

        //lua本地局部变量获取不到 
        //int local = LuaManager.GetInstance().Global.GetInPath<int>("testLocal");
        //Debug.Log("testLocal:" + local);

    }

    void Update()
    {
        
    }
}
