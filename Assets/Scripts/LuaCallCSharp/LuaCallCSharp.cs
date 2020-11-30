using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLua;

#region 第一次课

public class Test
{
    public void Speak(string str)
    {
        Debug.Log("test:" + str);
    }
}

namespace MyKeyber
{
    public class Test2
    {
        public void Speak(string str)
        {
            Debug.Log("test2:" + str);
        }
    }
}

#endregion

#region 枚举
enum MyEnum
{
    idle,
    walk,
    attack,
    run
}

#endregion

#region 数组 List 字典
public class Lesson3
{
    public int[] array = new int[5] { 1, 2, 3, 4, 5 };

    public List<int> list = new List<int>();

    public Dictionary<int, string> dic = new Dictionary<int, string>(); 
}

#endregion

#region 拓展方法
//如果想在lua中调用扩展方法 一定要在工具类面前加上特性
[LuaCallCSharp]//建议在lua中使用的类 都加上改特性 可以提升性能
//如果不加该特性 除了拓展方法对应的类 其他类的使用 都不会报错
//但是lua是通过反射的机制去调用的C#类 效率较低
public static class Tools
{
    //lesson4拓展方法
    public static void Move(this Lesson4 obj)
    {
        Debug.Log(obj.name + "Move");
    }
}

public class Lesson4
{
    public string name = "keyber";

    public void Speak(string str)
    {
        Debug.Log(str);
    }

    public static void Eat()
    {
        Debug.Log("吃东西");
    }

}

#endregion

#region ref和out

public class Lesson5
{
    public int RefFun(int a, ref int b,ref int c,int d)
    {
        b = a + b;
        c = a - d;
        return 100;
    }

    public int OutFun(int a,out int b,out int c,int d)
    {
        b = a;
        c = d;
        return 200;
    }

    public int RefOutFun(int a,out int b,ref int c) 
    {
        b = a + 10;
        c = a * 20;
        return 300;
    }
}

#endregion

#region 函数重载

public class Lesson6
{
    public int CallInt()
    {
        return 100;
    }

    public int CallInt(int a, int b)
    {
        return a + b;
    }
    public int CallInt(int a)
    {
        return a;
    }
    public float CallInt(float a)
    {
        return a;
    }

}

#endregion

#region 委托和事件

public class Lesson7
{
    //申明委托和事件
    public UnityAction unityAction;
    public delegate void CustomDelegate();
    public CustomDelegate customDelegate;

    public event UnityAction eventAction;
    public event CustomDelegate customAction;


    public void DoEvent()
    {
        eventAction?.Invoke();
    }
    public void ClearEvent()
    {
        eventAction = null;
        customAction = null;
    }
    public void DoEventCustom()
    {
        customAction?.Invoke();
    }
}

#endregion

#region 二维数组遍历

public class Lesson8
{
    public int[,] array = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
    

}

#endregion

#region 判空
//为Objec而拓展方法
[LuaCallCSharp]
public static class Lesson9
{
    //拓展一个Object方法，主要是给Lua用
    public static bool IsNull(this UnityEngine.Object obj)
    {
        return obj == null;
    }
}

#endregion

#region 系统类型加特性
public static class Lesson10
{
    [CSharpCallLua]
    public static List<Type> csharpCallLuaList = new List<Type>()
    {
        typeof(UnityAction<float>),
        typeof(UnityAction<bool>),
        typeof(CoustomCall)
    };

    [LuaCallCSharp]
    public static List<Type> luaCallCSharpList = new List<Type>()
    {
        typeof(GameObject)
    };
}

#endregion

#region 调用泛型方法
public class Lesson12
{
    public interface ITest
    {

    }

    public class TestFather
    {

    }

    public class TestChild : TestFather
    {

    }

    public void TestFun1<T>(T a,T b) where T: TestFather
    {
        Debug.Log("有参数有约束的泛型方法");

    }

    public void TestFun2<T>(T a)
    {
        Debug.Log("有参数，没有约束");
    }

    public void TestFun3<T>()where T: TestFather
    {
        Debug.Log("有约束,但是没有参数的泛型函数");
    }

    public void TestFun4<T>(T a) where T : ITest
    {

    }

}


#endregion


public class LuaCallCSharp : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
}
