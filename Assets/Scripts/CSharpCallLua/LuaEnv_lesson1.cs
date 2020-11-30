using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//引用命名空间
using XLua;


public class LuaEnv_lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //lua解析器 能够让我们在unity当中执行lua
        //一般情况下 保持它的唯一性
        LuaEnv env = new LuaEnv();

        //第一执行lua语言,第二个参数表示语言报错信息打出，第三个是打印出解析器
        env.DoString("print('hello lua')");

        //执行一个lua脚本 Lua知识点: require 多脚本执行
        //默认寻找脚本的路径 是在 Resources下 在这里估计是通过 Resources.Load去加载lua脚本 
        //后缀要是txt bytes等等
        env.DoString("require('Main')");
        //一般会去执行一个lua脚本

        //帮助我们清除lua中我们没有手动释放的对象 相当于垃圾回收
        //帧更新的时候执行 或者 切换场景时候执行
        env.Tick();

        //销毁lua解析器,基本上不会去销毁
        env.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
