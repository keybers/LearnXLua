print("主Lua脚本启动")

--判断全局函数
function IsNull(obj)
	if(obj == nil or obj:Equals(nil)) then
		return true
	end
	
	return false
end
--unity中写lua执行脚本
--xlua帮我们处理
--只要是执行lua脚本 都会自动进入我们的重定向函数中找文件


--require("Text")

--require("CallIEnum_lesson2")
--require("CallArray_lesson3")
--require("CallFunction_lesson4")
--require("CallFunction_lesson5")
--require("CallFunction_lesson6")
require("CallDelegate_lesson7")
--require("Special_lesson8")
--require("Special_lesson9")
--require("Special_lesson10")
--require("Coroutine_lesson11")
