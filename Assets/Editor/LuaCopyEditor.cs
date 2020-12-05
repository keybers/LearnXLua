using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LuaCopyEditor : Editor
{
    [MenuItem("XLua/自动生成TXT后缀的Lua")]
    public static void CopyLuaToText()
    {
        //首先要找到所有的Lua文件
        string path = Application.dataPath + "/Lua/";
        //判断路径是否存在
        if(!Directory.Exists(path))
            return;

        //得到每一个Lua文件的路径 才能迁移
        string[] strs = Directory.GetFiles(path,"*.lua");
        //然后把LUA文件拷贝到新文件当中
        //首先定义新路径
        string newPath = Application.dataPath + "/LuaTXT/";
        //判断新文件路径是否存在
        if(!Directory.Exists(newPath))
        {
            Directory.CreateDirectory(newPath);
        }
        else
        {
            string[] oldFilePath = Directory.GetFiles(newPath,".txt");
            foreach(var i in oldFilePath)
            {
                File.Delete(i);
            }
        }
        //为了避免一些被删除的Lua文件 不再使用 我们应该先清空目标文件
        List<string> newFilesPath = new List<string>();
        string newFilePath;
        foreach(var i in strs)
        {
            //得到文件名
            newFilePath = newPath + i.Substring(i.LastIndexOf("/") + 1 ) + ".txt";
            newFilesPath.Add(newFilePath);
            File.Copy(i,newFilePath);
        }

        AssetDatabase.Refresh();

        //该指定AB包标签
        foreach(var i in newFilesPath)
        {
            //该API传入的路径 必须是 相对Assets文件夹的 Assets/../..
            AssetImporter importer = AssetImporter.GetAtPath(i.Substring(i.IndexOf("Assets")));
            if(importer != null)
                importer.assetBundleName = "lua";
        }
    }
}
