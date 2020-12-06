print("*************泛型类的替换************")

--泛型类 T是可以变换的 那Lua中应该如何替换
--lua中的替换 要一个一个类型的来

xlua.hotfix(CS.HotfixTest2(CS.System.String),{
    Test = function (self,str)
        print("Lua中打的补丁：" .. str)
    end
})

xlua.hotfix(CS.HotfixTest2(CS.System.Int32),{
    Test = function (self,num)
        print("Lua中打的补丁：" .. num)
    end
})