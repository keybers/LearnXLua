using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour 
{
    private static T instace;

    public static T GetInstace()
    {
        return instace;
    }

    protected virtual void Awake()
    {
        instace = this as T;
    }
}
