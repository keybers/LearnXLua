using UnityEngine;

public class SingletonAutoMono<T> : MonoBehaviour where T : MonoBehaviour 
{
    private static T instance;

    public static T GetInstance()
    {
        if(instance == null)
        {
            GameObject obj = new GameObject();
            obj.name = typeof(T).ToString();
            DontDestroyOnLoad(obj);//让这个单例对象切换场景时候不删除，而是存在整个程序的生命周期当中
            instance = obj.AddComponent<T>();
        }
        return instance;
    }
}
