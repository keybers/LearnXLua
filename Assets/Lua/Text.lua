print("Test.Lua文件启动")
testNumber = 1
testBool = true
testFloat = 1.2
testString = "123"

--我们通过C# 没办法直接获得本地局部变量
local testLocal = 6

--无参无返回
testFun = function()
	print("无参数无返回")
end

--有参有返回
testFun2 = function(a)
	print("有参数有返回")
	return a + 1
end

--多返回
testFun3 = function(a)
	print("多返回值")
	return 1,2,false,"123",a
end

--变长参数
testFun4 = function(a, ...)
	print("变长参数")
	arg = {...}
	for k,v in pairs(arg) do
		print(k,v)
	end
end


--映射List
testList1 = {1,2,2,3,5,4,6,9}

testList2 = {"23","456",true,1,false,1.2}

--Dictionary

testDic1 = {
	["1"] = 4,
	["2"] = 3,
	["3"] = 5,
	["4"] = 5
}

testDic2 = {
	["1"] = false,
	[true] = "sfd",
	[1] = 4
}

--Lua当中的一个自定义类
testTable = {
	testInt = 2,
	testBool = true,
	testFloat = 2.2,
	testString = "sss",

	testFun = function()
		print("4ddddcc8787")
	end,
	
	testInClass = {
		testInInt = 789
	}
}
