print("************************Lua调用C# 二维数组相关知识*******************")

local obj = CS.Lesson8()

--获取长度
print("行:" .. obj.array:GetLength(0))
print("列:" .. obj.array:GetLength(1))

--获取元素
--不能通过[0,0]或者[0][0] 获取元素
--print(obj.array[0,0])

--使用数组提供的方法访问元素
print(obj.array:GetValue(0,0))
print(obj.array:GetValue(1,0))

--遍历
for i=0,obj.array:GetLength(0)-1 do
	for j=0,obj.array:GetLength(1)-1 do
		print(obj.array:GetValue(i,j))
	end
end

