PlayerData = {}
--目前只做背包功能 所以只i需要它的道具信息即可

PlayerData.equips = {} -- 装备
PlayerData.items = {}  -- 道具
PlayerData.gems = {}  -- 宝石

--为玩家数据写一了 初始化方法 所以直接改这里的数据来源即可
function PlayerData:Init()
    --道具信息 不管存本地 还是服务器 都不会把道具的所有信息都存进去
    --道具ID和道具数量

    --目前没有数据 为测试 把道具数据写死作为玩家信息
    table.insert(self.equips, {id = 1, num = 1})
    table.insert(self.equips, {id = 2, num = 1})

    table.insert(self.items, {id = 3, num = 20})
    table.insert(self.items, {id = 4, num = 6})
    
    table.insert(self.gems, {id = 5, num = 99})
    table.insert(self.gems, {id = 6, num = 99})

end
