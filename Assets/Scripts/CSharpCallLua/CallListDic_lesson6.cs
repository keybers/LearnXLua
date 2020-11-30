using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallListDic_lesson6 : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        //========================List同一类型======================================
        List<int> lualist = LuaManager.GetInstance().Global.GetInPath<List<int>>("testList1");
        for(int i = 0; i < lualist.Count; i++)
        {
            Debug.Log(lualist[i]);
        }

        lualist[0] = 100;
        //值拷贝 浅拷贝 不会改变lua中的内容
        List<int> lualist1 = LuaManager.GetInstance().Global.GetInPath<List<int>>("testList1");
        Debug.Log(lualist1[0]);
        //=====================List不指定类型=======================================
        List<object> luaObject = LuaManager.GetInstance().Global.GetInPath<List<object>>("testList2");
        for (int i = 0; i < luaObject.Count; i++)
        {
            Debug.Log(luaObject[i]);
        }
        //=============================字典统一类型==============================
        Dictionary<string, int> luaDic = LuaManager.GetInstance().Global.GetInPath<Dictionary<string, int>>("testDic1");
        foreach(string item in luaDic.Keys)
        {
            Debug.Log("luaDic:" + luaDic[item]);
        }
        //=========================字典不指定类型=================================
        Dictionary<object, object> luaDic1 = LuaManager.GetInstance().Global.GetInPath<Dictionary<object, object>>("testDic2");
        foreach (object item in luaDic1.Keys)
        {
            Debug.Log("luaDic1:" + luaDic1[item]);
            
        }
    }

}
