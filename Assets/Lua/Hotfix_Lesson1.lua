print("*************************第一个热补丁*****************************")

--直接写好会报错报错
--需要3步骤
-- 加特性 在热补丁前加[hotfix]
-- 加宏 在playersettings的scripting define symbols 中加HOTFIX_ENABLE 第一次用
-- 生成代码
--hotfix注入 注入时可能报错 提示要引入Tools

--热补丁的缺点：只要我们修改了热补丁类的代码 需要重新生成代码

--Lua当中 热补丁代码固定写法
--xlua.hotfix(类,"函数名",Lua函数)

--成员函数 第一个参数 self
xlua.hotfix(CS.HotfixMain,"Add",function (self,a,b)
    return a + b
end)


--静态方法不需要传自己
xlua.hotfix(CS.HotfixMain,"Speak",function (a)
        print(a)
end)