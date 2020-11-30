using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

//接口中是不允许有成员变量的
//我们用属性来接收
//不能写public
//接口和类的规则都一样 其中的属性多了少了 不影响结果 无非就是忽略他们
//嵌套几乎和类是一样 无非 是要遵循接口的规则
[CSharpCallLua]
public interface ICSharpCallInterface
{
    int testInt2
    {
        get;
        set;
    }

    bool testBool
    {
        get;
        set;
    }
    float testFloat
    {
        get;
        set;
    }
    string testString
    {
        get;
        set;
    }
    UnityAction testFun
    {
        get;
        set;
    }
}

public class CallInterface_lesson8 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        ICSharpCallInterface cSharpCallInterface = LuaManager.GetInstance().Global.GetInPath<ICSharpCallInterface>("testTable");
        Debug.Log(cSharpCallInterface.testBool);
        Debug.Log(cSharpCallInterface.testFloat);
        Debug.Log("新加的：" + cSharpCallInterface.testInt2);
        Debug.Log(cSharpCallInterface.testString);
        cSharpCallInterface.testFun();

        //可以判断是"引用拷贝" 不是值拷贝 通过改变值可以改变lua表中的相应的值
        cSharpCallInterface.testFloat = 100;
        ICSharpCallInterface cSharpCallInterface1 = LuaManager.GetInstance().Global.GetInPath<ICSharpCallInterface>("testTable");
        Debug.Log(cSharpCallInterface1.testFloat);

    }
}
