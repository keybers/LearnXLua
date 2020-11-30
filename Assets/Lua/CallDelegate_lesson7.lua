print("****************************lua调用C# 委托事件相关知识点**************************")

local obj = CS.Lesson7()

--委托是用来装函数的
--使用C#中的委托 就是用来装LUA函数的

local fun = function()
	print("Lua函数FUN")
end

local funcustom = function()
	print("custom函数调用")
end
--Lua中没有复合运算符 不能+=
--如果第一次往委托中加函数 因为是nil 不能直接+
--所以第一次 要先等=
obj.unityAction = fun
obj.unityAction = obj.unityAction + fun

obj.customDelegate = funcustom
obj.customDelegate = obj.customDelegate + funcustom

print("****************加函数****************")
--obj.unityAction()
obj.customDelegate()
--不建议这样写，最好还是声明后再加，不清楚匿名函数
obj.unityAction = obj.unityAction + function ()
	print("临时申明的函数")
end

obj.unityAction()

print("****************减函数****************")
obj.unityAction = obj.unityAction - fun
obj.unityAction()

--清空
obj.unityAction = nil
print("****************清空****************")

obj.unityAction = fun
obj.unityAction()

print("*********************lua调用C# 事件相关知识点*******************")

local fun2 = function ()
	print("事件加的函数")
end

--事件加函数 和 委托非常不一样
--lua中使用C#事件 加函数
--有点类似使用成员方法 冒号事件名("+",函数变量)
obj:eventAction("+", fun2)
--最好不这样写 匿名不好去除
obj:eventAction("+", function ()
	print("匿名函数")
end)

obj:DoEvent()
print("*************减事件********************")
obj:eventAction("-", fun2)

obj:DoEvent()
print("*************事件清除*******************")
--清空事件不能设置 nil，只能调用C#中方法制空null
--obj.eventAction = nil

--事件和委托是两个概念：前者是运行某一函数时，调用多个函数。后者是调用一个代表调用多个函数的集合