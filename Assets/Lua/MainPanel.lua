--只要是一个新面板 就新建一个对象
MainPanel = {}

--不是必须写 因为Lua的特性 不存在声明变量的概念
--这样写的目的是为了他人方便阅读
--关联面板对象
MainPanel.panelObj = nil
MainPanel.ButtonRole = nil
MainPanel.ButtonSkill = nil

--需要做 实例化面板对象
--为这个面板 处理对应的逻辑 比如按钮点击等等

--初始化该面板 实例化对象 控件事件监听
function MainPanel:Init()

    --面板对象没有实例化过 才去实例化处理
    if  self.panelObj == nil then
        --实例化面板对象
        self.panelObj = ABManager:LoadRes("ui","MainPanel",typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas,false) --false表示保持原有的缩放比例
        --找到对应控件
        --找到子对象 再找到身上挂在身上的脚本
        self.ButtonRole = self.panelObj.transform:Find("ButtonRole"):GetComponent(typeof(Button))
        print(self.ButtonRole)

        --为控件加上事件监听 进行点击等等的逻辑处理

        --如果直接.传入自己的函数 那么在函数内部 没有办法用self获取内容
        --self.ButtonRole.onClick:AddListener(self.OnClickRole)
        --用匿名函数包裹一层
        self.ButtonRole.onClick:AddListener(function()
            self:OnClickRole()
        end)
    end

end


function MainPanel:Show()
    self:Init()
    self.panelObj:SetActive(true)
end

function MainPanel:Hide()
    self.panelObj:SetActive(false)
end

function MainPanel:OnClickRole()
    print(123123)
    --打印自己，谁调用就用谁，不局限于MainPanel
    print(self.panelObj)

    --写背包面板
    BagPanel:Show()
end