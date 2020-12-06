print("**************************协程函数的替换********************")


util = require("xlua.util")
xlua.hotfix(CS.HotfixMain,
{
    TestCoroutine = function (self)
        --返回一个xlua处理过的lua协程函数
        return util.cs_generator(function ()
            while true do
                coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
                print("Lua打补丁后的协程函数")
            end
        end)
    end
})

--如果我们为打入了hotfix特性的C#类新加了函数的内容
--不能只注入 必须要先生成代码在注入
