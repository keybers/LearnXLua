using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using XLua;
using UnityEngine.Events;
public static class CSharpCallLuaList
{
    [CSharpCallLua]
    public static List<Type> cSharpCallLuaList = new List<Type>(){
        typeof(UnityAction<bool>)
    };

}