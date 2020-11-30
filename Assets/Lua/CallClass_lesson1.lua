print("**************************Lua调用C#类相关知识点************************")

--lua中使用C#的类非常简单
--固定套路哦
--CS.命名空间.类名
--Unity中的类 比如 GameObject Transform等等 --CS.UnityEngine.类名
--CS.UnityEngine.GameObject

--通过C#中的类 实例化一个对象 lua中没有new 所以我们直接 类名括号就是实例化对象
--默认调用的 相当于就是无参构造
local obj1 = CS.UnityEngine.GameObject()
local obj2 = CS.UnityEngine.GameObject("Keyber")


--为了方便 节约性能 定义全局变量存储 C#中的类
GameObject = CS.UnityEngine.GameObject
local obj3 = GameObject("keyberI")

--类中的静态对象 可以直接使用 来调用
local obj4 = GameObject.Find("Keyber")

--得到对象中的成员变量 直接对象 即可
print(obj4.transform.position)
Debug = CS.UnityEngine.Debug
Debug.Log(obj4.transform.position)

Vector3 = CS.UnityEngine.Vector3
--如果使用对象中的 成员方法！！ 一定要加:
obj4.transform:Translate(Vector3.right)
Debug.Log(obj4.transform.position)

local t = CS.Test()
t:Speak("test说话")

local t2 = CS.MyKeyber.Test2()
t2:Speak("test2说话")

--继承了Mono的类
--继承了Mono的类 是不能直接new
local obj5 = GameObject("加脚本测试")
--通过GameObject的AddComponent添加脚本
--xlua提供了一个重要方法 typeof 可以得到类的Type
--Xlua中不支持无参泛型函数 所以我们要使用另一个重载
obj5:AddComponent(typeof(CS.LuaCallCSharp))
