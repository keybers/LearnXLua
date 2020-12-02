print("*************************LUA调用C# 泛型函数相关知识点*************************")

local obj = CS.Lesson12()

local child = CS.Lesson12.TestChild()
local father = CS.Lesson12.TestFather()

--支持有约束有参数的泛型参数
obj:TestFun1(child,father)
obj:TestFun1(father,child)

--Lua中不支持 没有约束的泛型参数
--obj:TestFun2(child)

--Lua中不支持 有约束但是没有参数的泛型函数
--obj:TestFun3()

--Lua中不支持 非Class的约束
--obj:TestFun4(child)



--有一定的使用限制
--如果使用的是Mono打包，则可以使用
--如果使用iL2cpp打包 如果泛型参数是引用类型才可以使用
--如果使用iL2cpp打包 如果泛型参数是值类型 除非C#那边已经调用过了 同类型的泛型参数 lua中才能够被使用

--补充知识 让上面 不支持使用的泛型参数 变得能用
--得到通用函数
--设置泛型类型再使用

--xlua.get_generic_method(类,"函数名")
local testFun2 = xlua.get_generic_method(CS.Lesson12,"TestFun2")
--声明了指定类型的泛型参数
local testFun2_R = testFun2(CS.System.Int32)
--调用
--成员方法 第一个参数调用函数对象 静态方法不用传自己
testFun2_R(obj,1)


