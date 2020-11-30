GameObject = CS.UnityEngine.GameObject
UI = CS.UnityEngine.UI

local slider = GameObject.Find("Slider")
print(slider)
local sliderScript = slider:GetComponent(typeof(UI.Slider))
print(sliderScript)

sliderScript.onValueChanged:AddListener(function (f)
	print(f)
end
)

local button = GameObject.Find("Button")
local buttonScript = button:GetComponent(typeof(UI.Button))
buttonScript.onClick:AddListener(function (f)
	print(f)
end)



