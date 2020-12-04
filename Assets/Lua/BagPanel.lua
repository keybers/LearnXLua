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

--来存储当前 显示的格子 不能设为nil
BagPanel.items = {}
--2.成员方法
--初始化方法
function BagPanel:Init()
    if self.panelObj == nil then
        --实例化面板对象
        self.panelObj = ABManager:LoadRes("ui","BagPanel",typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas,false)
        --找控件
        self.ButtonClose = self.panelObj.transform:Find("ButtonClose"):GetComponent(typeof(Button))

        local Group = self.panelObj.transform:Find("Group")

        self.ToggleEquip = Group:Find("ToggleEquip"):GetComponent(typeof(Toggle))
        self.ToggleGem = Group:Find("ToggleGem"):GetComponent(typeof(Toggle))
        self.ToggleItem = Group:Find("ToggleItem"):GetComponent(typeof(Toggle))

        self.SVBag = self.panelObj.transform:Find("SVBag"):GetComponent(typeof(ScrollRect))
        self.Content = self.SVBag.transform:Find("Viewport"):Find("Content")
        --加事件

        --关闭按钮
        self.ButtonClose.onClick:AddListener(function()
            self:Hide()
        end)

        --单选框事件
        --切页机
        --toggle 对应委托，也就是现在的addlistener后的匿名函数  是unityAction<bool>
        --因为UnityAction是系统委托没办法应用到LUA，所以要创建一个csharp类，里面添加静态列表
        --onValueChanged会传入true or false 
        --都是使用监听传给委托函数 有参无参都是unityaction，无参数可以使用Lua函数，但是有参必须使用unityaction委托的函数
        self.ToggleEquip.onValueChanged:AddListener(function(value)
            if  value == true then
                self:ChangeType(1)
            end
        end)

        self.ToggleItem.onValueChanged:AddListener(function(value)
            if  value == true then
                self:ChangeType(2)
            end
        end)

        self.ToggleGem.onValueChanged:AddListener(function(value)
            if  value == true then
                self:ChangeType(3)
            end
        end)

    end
end

--显示隐藏方法
function BagPanel:Show()
    self:Init()
    self.panelObj:SetActive(true)
end

function BagPanel:Hide()
    self.panelObj:SetActive(false)
end

--逻辑处理函数
--切页签 type 1装备 2道具 3宝石
function BagPanel:ChangeType(type)
    --根据玩家信息 来进行格子创建

    --更新之前 把老格子删除 BagPanel.items

    --再根据当前选择的类型 来创建新的格子 BagPanel.items

    --根据传入的type来选择 显示传入的数据
    local nowItems = nil

    if type == 1 then
        nowItems = PlayerData.equips
    elseif type == 2 then
        nowItems = PlayerData.items
    else --3
        nowItems = PlayerData.gems
    end

    --一个格子表示一个对象 所以不需要创建N个对象脚本 通过临时创建一个空表对象grid来设置
    --创建格子
    for i = 1, #nowItems do
        --有格子资源 在这加载格子资源 实例化 改变图片 和文本 以及位置即可
        --用一张新表 代表格子对象 里面的属性 存储对应想要的信息
        local grid = {}
        grid.Object = ABManager:LoadRes("ui","ItemGrid");
        --设置父对象
        grid.Object.transform:SetParent(self.Content,false)
        --设置位置 x+75,y-75是初始位置
        grid.Object.transform.localPosition = Vector3((i-1)%4*150 + 75, math.floor((i-1)/4)*150 - 75, 0)
        --设置图标
        grid.imgIcon = grid.Object.transform:Find("imgIcon"):GetComponent(typeof(Image))
        grid.Text = grid.Object.transform:Find("Text"):GetComponent(typeof(Text))
        --设置数量
        --通过 道具ID 去读取 道具配置表信息 得到图标信息
        local data = ItemData[nowItems[i].id]
        --想要的是data中的 图标信息
        --根据名字 先加载图集 再加载图集中的 图标信息
        local strs = string.split(data.icon,"_")
        --加载图集
        local spriteAtlas = ABManager:LoadRes("ui",strs[1],typeof(SpriteAtlas))
        --加载图标
        grid.imgIcon.sprite = spriteAtlas:GetSprite(strs[2])
        --设置它的数量
        grid.Text.text = nowItems[i].num

        --存入当前容器
        table.insert(self.items,grid)
        print("存入容器")
        print(self.items)
    end
end


