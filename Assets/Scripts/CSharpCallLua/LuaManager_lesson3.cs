using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaManager_lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //初始化解析器
        LuaManager.GetInstance().Init();

        //Lua重定向
        LuaManager.GetInstance().DoLuaFile("Main");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
