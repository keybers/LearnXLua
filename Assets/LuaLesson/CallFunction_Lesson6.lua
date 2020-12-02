print("*******************************Lua调用C# 重载函数相关知识点*****************************")

local obj = CS.Lesson6()

--Lua本身不支持重载
--Lua支持调用C#中的重载函数

print(obj:CallInt())
print(obj:CallInt(4))
--lua虽然支持调用C#重载函数。但是因为Lua中的数值只有number，对C#多精度的重载函数支持不好，在使用时可能出现意外
print(obj:CallInt(4.1))
print(obj:CallInt(1,3))

--解决重载函数含糊的问题
--xlua提供了解决方案 反射机制 做了解最好不用
--type是反射的关键类
print("******************************不要求掌握 了解就行****************************")

local m1 = typeof(CS.Lesson6):GetMethod("CallInt",{typeof(CS.System.Int32)})
local m2 = typeof(CS.Lesson6):GetMethod("CallInt",{typeof(CS.System.Single)})
--通过Xlua提供的一个方法 把它转成lua函数来使用
--一般我们转一次 然后重复使用
local f1 = xlua.tofunction(m1)
local f2 = xlua.tofunction(m2)
--成员方法 第一个参数传对象
--静态方法 不用传对象
print(f1(obj,10))
print(f2(obj,10.2))