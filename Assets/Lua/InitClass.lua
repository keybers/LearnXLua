--常用别名都在这里面定位
--准备我们自己之前导入的脚本
--面向对象相关
require("Object")
--字符串拆分
require("SplitTools")
--JSON解析
Json = require("JsonUtility")


--unity相关的
GameObject = CS.UnityEngine.GameObject
Resources = CS.UnityEngine.Resources
Transform = CS.UnityEngine.Transform
RecTransform = CS.UnityEngine.RecTransform
TextAsset = CS.UnityEngine.TextAsset

--图集对象类
SpriteAtlas = CS.UnityEngine.U2D.SpriteAtlas

Vector3 = CS.UnityEngine.Vector3
Vector2 = CS.UnityEngine.Vector2

--UI相关的
UI = CS.UnityEngine.UI
Image = UI.Image
Text = UI.Text
Button = UI.Button
Toggle = UI.Toggle
ScrollRect = UI.ScrollRect
UIBehaviour = CS.UnityEngine.EventSystems.UIBehaviour

--对于该项目来说 是找一次就行了
Canvas = GameObject.Find("Canvas").transform

--自己写的C#脚本相关
--直接得到AB包资源管理的器的资源对象
ABManager = CS.ABManager.GetInstance()
