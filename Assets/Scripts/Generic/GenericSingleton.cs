using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>, new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }
    protected virtual void Awake()
    {
        if (instance == null)
            instance = this as T;
        else
            Destroy(this);
    }

}
