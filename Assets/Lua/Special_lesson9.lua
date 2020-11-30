print("*************************Lua调用 nil和null比较的相关知识点****************")

--往场景上添加一个脚本 如果存在就不加 如果不存在就不加
GameObject = CS.UnityEngine.GameObject
Rigidbody = CS.UnityEngine.Rigidbody

local obj = GameObject("测试加脚本")
--得到身上的刚体组件 如果没有就添加 
local rig = obj:GetComponent(typeof(Rigidbody))
print(rig)
--判断空
--nil 和 null 没有办法去比较
-- nil == null
--得使用方法Equals(nil)

--第一种方法 调用该方法的对象前提是一个object
--if obj:Equals(rig) then
--第二种 调用Lua中自定义方法
--IsNull(rig)
--第三种 在C#定义拓展方法
if rig:IsNull(rig) then
	print("123")
	rig = obj:AddComponent(typeof(Rigidbody))
end
print(rig)


