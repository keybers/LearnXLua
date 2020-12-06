print("******************事件加减替换***************")

xlua.hotfix(CS.HotfixMain, {
    --add_事件名 代表着事件加操作
    --remove_事件名 减操作

    add_unityAction = function (self,del)
        print(del)
        print("添加事件函数")
        --会去尝试使用Lua使用C#事件的方法去添加
        --在事件加减的重定向lua函数中
        --千万不要把传入的委托事件往事件里面存
        --否则会死循环
        --self:TestDelegate("+",del)
    end,

    remove_unityAction = function (self,del)
        print(del)
        print("添加事件函数")
    end
})