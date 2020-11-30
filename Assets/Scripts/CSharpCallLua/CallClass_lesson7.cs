using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallLuaClass
{
    //在这个类中去声明成员变量
    //名字一定要和Lua那边表一样
    //一定要是公共的 私有和保护的没办法赋值
    public int testInt;
    public bool testBool;
    public float testFloat;
    public string testString;

    //函数用委托装，函数名一定要一致
    public UnityAction testFun;

    //这个自定义中的变量可以更多 也可以更少 如果变量比lua中的少则会被忽略 如果变量比lua中的多也会被忽略
    public void Test()
    {
        Debug.Log(testInt);
    }

    public testInClass testInClass;
}

public class testInClass
{
    public int testInInt;
}

public class CallClass_lesson7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        CallLuaClass callLuaClass = LuaManager.GetInstance().Global.GetInPath<CallLuaClass>("testTable");
        Debug.Log(callLuaClass.testInt);
        Debug.Log(callLuaClass.testFloat);
        Debug.Log(callLuaClass.testBool);
        Debug.Log(callLuaClass.testString);
        callLuaClass.testFun();
        callLuaClass.Test();
        Debug.Log("嵌套：" + callLuaClass.testInClass.testInInt);

        //测试是值拷贝还是引用拷贝,答案是值拷贝 浅拷贝 不会改变lua表中的内容
        callLuaClass.testInt = 100;
        CallLuaClass callLuaClass1 = LuaManager.GetInstance().Global.GetInPath<CallLuaClass>("testTable");
        Debug.Log(callLuaClass1.testInt);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
