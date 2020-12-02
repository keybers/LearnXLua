--一个面板对应一个表
BagPanel = {}

--1.成员变量
--面板对象
BagPanel.panelObj = nil

--各个控件
BagPanel.ButtonClose = nil

BagPanel.ToggleEquip = nil
BagPanel.ToggleItem = nil
BagPanel.ToggleGem = nil

BagPanel.SVBag = nil
BagPanel.Content = nil

--2.成员方法
--初始化方法
function BagPanel:Init()
    if self.panelObj == nil then
        --实例化面板对象
        self.panelObj = ABManager:LoadRes("ui","BagPanel",typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas,false)
        --找控件
        
        --加事件

    end
end

--显示隐藏方法
function BagPanel:Show()
    self:Init()
    self.panelObj:SetActive(true)
end

function BagPanel:Close()
    self.panelObj:SetActive(false)
end


