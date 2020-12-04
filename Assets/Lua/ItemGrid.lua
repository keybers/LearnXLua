--用到之前讲过的知识 Object,只有先继承了Object类才可以使用Object的方法，ItemGrid继承Object
Object:subClass("ItemGrid")
--实例化格子对象
ItemGrid.Object = nil
ItemGrid.imgIcon = nil
ItemGrid.Text = nil

--成员函数
--实例化格子对象
function ItemGrid:Init(father,posX,posY)
    --实例化格子对象
    self.Object = ABManager:LoadRes("ui","ItemGrid");
    --设置父对象
    self.Object.transform:SetParent(father,false)
    --设置位置 x+75,y-75是初始位置
    self.Object.transform.localPosition = Vector3(posX, posY, 0)
    --设置图标
    self.imgIcon = self.Object.transform:Find("imgIcon"):GetComponent(typeof(Image))
    self.Text = self.Object.transform:Find("Text"):GetComponent(typeof(Text))
end
--初始化格子信息
--data 是外面传入的 道具信息 里面包含 id和num
function ItemGrid:InitData(data)
    --设置数量
    --通过 道具ID 去读取 道具配置表信息 得到图标信息
    local dataID = ItemData[data.id]
    --想要的是data中的 图标信息
    --根据名字 先加载图集 再加载图集中的 图标信息
    local strs = string.split(dataID.icon,"_")
    --加载图集
    local spriteAtlas = ABManager:LoadRes("ui",strs[1],typeof(SpriteAtlas))
    --加载图标
    self.imgIcon.sprite = spriteAtlas:GetSprite(strs[2])
    --设置它的数量
    self.Text.text = data.num
end

function ItemGrid:Destroy()
    GameObject.Destroy(self.Object)
    self.Object = nil
end
--加自己的逻辑