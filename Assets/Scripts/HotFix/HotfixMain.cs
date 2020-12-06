using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using UnityEngine.Events;

[Hotfix]
public class HotfixTest
{
    public HotfixTest()
    {
        Debug.Log("Hotfix构造函数");
    }

    public void Speak(string str)
    {
        Debug.Log(str);
    }

    ~HotfixTest()
    {
        Debug.Log("我是析构函数");
    }
}

[Hotfix]
public class HotfixMain : MonoBehaviour
{
    HotfixTest hotfix;
    private int[] array = new int[]{1,2,3};

//属性
    public int Age
    {
        get{
            return 0;
        }
        set{
            Debug.Log(value);
        }
    }
/// <summary>
/// 索引器
/// </summary>
/// <value></value>
    public int this[int index]
    {
        get{
            if(index >= array.Length || index < 0){
                Debug.Log("索引不正确");
                return 0;
            }
            return array[index];
        }
        set{
            if(index >= array.Length || index < 0){
                Debug.Log("索引不正确");
                return;
            }
            array[index] = value;
        }
    }

    event UnityAction unityAction;
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        Debug.Log(Add(10,20));
        Speak("NB");

        hotfix = new HotfixTest();
        hotfix.Speak("jfdisjfi");

        //StartCoroutine(TestCoroutine());

        this.Age = 100;
        Debug.Log(this.Age);

        this[99] = 100;
        Debug.Log(this[9999]);

        unityAction += TestDelegate;

        unityAction -= TestDelegate;

        HotfixTest2<string> t1 = new HotfixTest2<string>();
        t1.Test("123456");

        HotfixTest2<int> t2 = new HotfixTest2<int>();
        t2.Test(20000);

    }

    public void TestDelegate(){

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TestCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("协程函数打印一次");
        }
    }

    public int Add(int a, int b)
    {
        return 0;
    }

    public static void Speak(string str)
    {
        Debug.Log("hhhhhh");
    }

}

[Hotfix]
public class HotfixTest2<T>{
    public void Test(T str){
        Debug.Log(str);
    }
}
