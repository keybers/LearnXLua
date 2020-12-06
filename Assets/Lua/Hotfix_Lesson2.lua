print("*************多函数替换*********************")

--xlua.hotfic(类，{函数名 = 函数，函数名 = 函数 。。。。})
xlua.hotfix(CS.HotfixMain,{
    Update = function (self)
        print(os.time())
    end,
    Add = function (self,a,b)
        return a+b
    end,
    Speak = function (a)
        print(a)
    end
})

xlua.hotfix(CS.HotfixTest,
{
    --构造函数 热补丁固定写法
    --他们和别的的函数不同 不是替换 是先调用原逻辑 在调用Lua逻辑
    --根据版本不同：成员函数没有执行原逻辑
    [".ctor"] = function ()
        print("Lua热补丁构造函数")
    end,
    Speak = function (self,a)
        print("keyber" .. a)
    end,
    --析构函数的固定写法Finalize
    Finalize = function ()
        print("我是改后的的析构函数")
    end
})