print("*************************Lua调用数组 list dictionary相关知识点")

local obj = CS.Lesson3()
--Lua使用C#数组相关知识
--获取长度:C#怎么用 Lua就怎么用 不能使用#去获取长度
print(CS.Lesson3().array.Length)

--访问元素
print(obj.array[0])

--遍历要注意 虽然lua中索引从1开始

--但是数组是C#那边的规则 所以 还是得按C#来
--注意最大值 一定要减1
 for i = 0 , obj.array.Length - 1 do
 	print(obj.array[i])
 end

 --在lua中创建一个C#的数组 Lua中表示数组和List可以用表
 --但是我要使用C#中？？？
 --创建C#中的数组 使用 Array类中的静态方法CreateInstance
local array2 = CS.System.Array.CreateInstance(typeof(CS.System.Int32),10)

print(array2.Length)
print(array2[0])
print(array2[1])
print(array2)

print("*****************************Lua调用C# list相关知识点**************************")
--调用成员方法用：
obj.list:Add(1)
obj.list:Add(51)
obj.list:Add(7)

--长度
print(obj.list.Count)
--遍历
for i=0, obj.list.Count - 1 do
	print(obj.list[i])
end

print(obj.list)

--在lua中创建一个list对象
--老版本
local list2 = CS.System.Collections.Generic["List`1[System.String]"]()
print(list2)
list2:Add("123")
print(list2[0])
--新版本
--相当于得到了一个 List<String> 的一个类别名 需要再实例化
local List_String = CS.System.Collections.Generic.List(CS.System.String)
local list3 = List_String()
list3:Add(78)
print(list3[0])

print("****************************lua调用C# dictionary相关知识点**********************")

--使用和C#一致
obj.dic:Add(1,"fdss")
print(obj.dic[1])

--遍历
for k,v in pairs(obj.dic) do
	print(k,v)
end

--在lua中创建一个字典对象
--相当于得到了一个 Dictionary<String,Vector3>的一个类别名 需要再实例化
local dic_String_Vector3 = CS.System.Collections.Generic.Dictionary(CS.System.String, CS.UnityEngine.Vector3)
local dic2 = dic_String_Vector3()

dic2:Add("123",CS.UnityEngine.Vector3.right)
for k,v in pairs(dic2) do
	print(k,v)
end
--再lua中创建的字典 直接通过键中的括号得 得不到是nil
print(dic2["123"])
--用trygetvalue获取
print(dic2:TryGetValue("123"))
--如果要通过键获取值 要通过这个固定方法
--如果通过lua字典 新建字典，只能通过这种方法获得
print(dic2:get_Item("123"));
dic2:set_Item("123",nil)
print(dic2:get_Item("123"))



