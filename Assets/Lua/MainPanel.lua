--只要是一个新面板 就新建一个对象
BasePanel:subClass("MainPanel")

--需要做 实例化面板对象
--为这个面板 处理对应的逻辑 比如按钮点击等等

--初始化该面板 实例化对象 控件事件监听
function MainPanel:Init(name)
    self.base.Init(self,name)

    --为了只监听一次事件
    if self.isInitEvent == false then
        self:GetControl("ButtonRole","Button").onClick:AddListener(function()
            self:OnClickRole()
        end)
        self.isInitEvent = true
    end
end

function MainPanel:OnClickRole()
    --打印自己，谁调用就用谁，不局限于MainPanel
    --print(self.panelObj)

    --写背包面板
    BagPanel:Show("BagPanel")
end