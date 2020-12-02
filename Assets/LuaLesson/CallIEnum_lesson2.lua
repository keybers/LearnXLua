print("*****************************Lua调用C#枚举相关知识点**********************")


--枚举调用
--调用unity当中的枚举
--枚举调用的规则 和 类调用的规则是一样的
--CS.命名空间.枚举名.枚举成员
PrimitiveType = CS.UnityEngine.PrimitiveType
GameObject = CS.UnityEngine.GameObject

local obj = GameObject.CreatePrimitive(PrimitiveType.Cube)

--自定义枚举 使用方法一样 知识注意命名空间即可
MyEnum = CS.MyEnum
local c = MyEnum.idle
print(c)
--枚举转换相关
--数值转枚举
local a = MyEnum.__CastFrom(1)
print(a)

local b = MyEnum.__CastFrom("attack")
print(b)

--枚举不存在实例化，和类的使用很像