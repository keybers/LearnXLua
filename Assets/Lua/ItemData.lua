
--将Json数据读取到Lua中的表中进行存储

--首先应该先把json表 从ab包加载出来
--加载的json文件 TextAsset对象
local txt = ABManager:LoadRes("json","ItemData",typeof(TextAsset))
--获取它的文本信息 进行json解析

print(txt.text)
--json数据转换为table
local itemList = Json.decode(txt.text)
print(itemList[1].id .. itemList[1].name)
--加载出来是像一个数组结构的数据
--不方便我们通过 id 去获取里面的内容 所以 我们用一张新表转存一次
--而且这张 新的道具表 在任何地方 都能够被使用
--一张用来存储道具信息的表
--键值对形式 键是道具的ID 值是道具表一行信息
ItemData = {}
for _,value in pairs(itemList) do
    ItemData[value.id] = value
end

-- for key,value in pairs(ItemData) do
--     print(key,value)
-- end

print(ItemData[1].tips)