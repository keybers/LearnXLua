using System;
using UnityEngine;
using UnityEngine.Events;
using XLua;

//无参数无返回值委托，因为Xlua已经处理了所以认识
public delegate void CoustomCall();

//处理了，该特性是在Xlua的命名空间中的
[CSharpCallLua]
//有参有返回的委托，没处理所以不认识
public delegate int CoustomCallInt(int a);
//多返回值委托
[CSharpCallLua]
public delegate int CoustomCallMany(int a, out int b, out bool c, out string d, out int e);
//ref
[CSharpCallLua]
public delegate int CoustomCallMany1(int a, ref int b, ref bool c, ref string d, ref int e);

//变长参数的类型是根据实际情况传入的
[CSharpCallLua]
public delegate void CoustomCallChange(string a, params object[] args);

public class CallFunction_lesson5 : MonoBehaviour
{
    private void Start()
    {
        LuaManager.GetInstance().Init();

        LuaManager.GetInstance().DoLuaFile("Main");
        //四种获取Lua脚本中的函数的方式  总结就两种
        //无参数无返回
        //自定义委托
        CoustomCall Call = LuaManager.GetInstance().Global.GetInPath<CoustomCall>("testFun");
        Call();

        //Unity自带的委托,无参数无返回
        UnityAction unityAction = LuaManager.GetInstance().Global.GetInPath<UnityAction>("testFun");
        unityAction();

        //C#提供的委托 “建议用这种”
        Action action = LuaManager.GetInstance().Global.GetInPath<Action>("testFun");
        action();

        //XLua自带提供的一种获取函数的方式 和委托很类似 少用
        LuaFunction luaFunction = LuaManager.GetInstance().Global.GetInPath<LuaFunction>("testFun");
        luaFunction.Call();
        //==================无返回值=======================

        //有参有返回   //自定义委托不做处理会报错
        CoustomCallInt coustomCallInt = LuaManager.GetInstance().Global.GetInPath<CoustomCallInt>("testFun2");
        Debug.Log("CoustomCallInt:" + coustomCallInt(5));

        //C#自带的泛型委托 方便我们使用 建议用这种
        Func<int, int> sFun = LuaManager.GetInstance().Global.GetInPath<Func<int, int>>("testFun2");
        Debug.Log("Func:" + coustomCallInt(5));

        //unity没有自带的泛型委托
        //Xlua自带泛型委托
        LuaFunction luaFunctionT = LuaManager.GetInstance().Global.GetInPath<LuaFunction>("testFun2");
        Debug.Log("LuaFunctionT:" + luaFunctionT.Call(6)[0]);

        //============================单返回值=============================
        
        //使用out 和 ref 来接收 自定义委托函数接收多返回值
        CoustomCallMany coustomCallMany = LuaManager.GetInstance().Global.GetInPath<CoustomCallMany>("testFun3");
        int b;
        bool c;
        string d;
        int e;
        //知识点：out的值不需要初始化,好处在于可以不用通过函数返回得到返回值
        Debug.Log("第一个返回值：" + coustomCallMany(9, out b, out c, out d, out e));
        Debug.Log("处理后返回值：" + b + "_" + c + "_" + d + "_" + e);

        CoustomCallMany1 coustomCallMany1 = LuaManager.GetInstance().Global.GetInPath<CoustomCallMany1>("testFun3");
        int b1 = 0;
        bool c1 = true;
        string d1 = null;
        int e1 = 0;
        Debug.Log("第一个返回值：" + coustomCallMany1(100, ref b1, ref c1, ref d1, ref e1));
        Debug.Log("处理后返回值：" + b1 + "_" + c1 + "_" + d1 + "_" + e1);

        //Xlua
        LuaFunction luaFunction1 = LuaManager.GetInstance().Global.GetInPath<LuaFunction>("testFun3");
        object[] objs = luaFunction1.Call(1000);
        for(int i = 0; i < objs.Length; i++)
        {
            Debug.Log("第" + i + "个返回值：" + objs[i]);
        }

        //============================多返回值=============================

        CoustomCallChange coustomCallChange = LuaManager.GetInstance().Global.GetInPath<CoustomCallChange>("testFun4");
        coustomCallChange("456", 1, "fd", false, 4);

        LuaFunction luaFunction2 = LuaManager.GetInstance().Global.GetInPath<LuaFunction>("testFun4");
        luaFunction2.Call("456", 7878, 1012, false, "dd");

        //============================变长参数==============================


    }
}
