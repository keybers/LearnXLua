--利用面向对象
Object:subClass("BasePanel")

BasePanel.panleObject = nil
--相当于模拟一个字典 键为 控件名 值为控件本身 [存储所有控件]
BasePanel.controls = {}
--事件监听标识
BasePanel.isInitEvent = false

function BasePanel:Show(name)
    self:Init(name)
    self.panleObject:SetActive(true)
end

function BasePanel:Close()
    self.panleObject:SetActive(false)
end

function BasePanel:Init(name)
    if self.panleObject == nil then
        --实例化对象
        self.panleObject = ABManager:LoadRes("ui",name,typeof(GameObject))
        self.panleObject.transform:SetParent(Canvas,false)
        --绑定对应控件
        local allControls = self.panleObject:GetComponentsInChildren(typeof(UIBehaviour))
        --因为是Csharp中的数据，所以是从0开始
        --如果存入的控件都继承了uibehaviour所以都找继承的的儿子 但是存在一些无用的控件也被存储在字典里
        --通过设定命名规则来选择存入
        --Button Button名字
        --Toggle Toggle名字
        --Image img名字
        --ScrollRect SV名字

        --可能存在一个控件对象存多次的情况
        for i = 0, allControls.Length - 1 do
            local controlName = allControls[i].name
            --为了让我们得的时候 能够确定得的控件类型 所以我们需要存储类型
            --利用反射得到控件类名
            local typeName = allControls[i]:GetType().Name
            --按照名字的规则 去找控件 必须满足命名规则 才能存储
            if  string.find(controlName,"Button") ~= nil or
                string.find(controlName,"Toggle") ~= nil or
                string.find(controlName,"img") ~= nil or
                string.find(controlName,"SV") ~= nil then
                --避免出现一个对象上 挂在在多个UI控件中 出现覆盖的问题
                --都会被存到一个容器中 相当于数列数组
                --如果已经存在对象，则将该表存入对象中的为另一个表 否则新建一个表
                --最终的存储形式
                --{ButtonRole = {Image = 控件，Button = 控件}}
                if self.controls[controlName] ~= nil then
                    --通过自定义索引的形式 去加一个新的“成员变量”
                    self.controls[controlName][typeName] = allControls[i]
                else
                    --[typeName]自定义索引 属性
                    self.controls[controlName] = {[typeName] = allControls[i]}
                end
            end
        end
        
        --设置监听事件
    end
end

--得到控件 根据 控件依附对象的名字 和控件的类型
function BasePanel:GetControl(name,typeName)
    if self.controls[name] ~= nil then
        local sameNameControls = self.controls[name]
        if sameNameControls[typeName] ~= nil then
            return sameNameControls[typeName]
        end
    end
    return nil
end