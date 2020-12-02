print("**************准备就绪*******************")
--初始化所有准备好的类别名
require("InitClass")
--初始化道具表信息
require("ItemData")

--玩家信息获取
--1.从本地读取 本地存储有几种方式 PlayerPrefabs 和 json 或者二进制
--2.网络游戏 从服务器读取
require("PlayerData")
PlayerData:Init()


--之后的逻辑可以直接使用
require("MainPanel")
require("BagPanel")

MainPanel:Show()