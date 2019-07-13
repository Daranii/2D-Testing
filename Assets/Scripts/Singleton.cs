using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object Lock = new object();

    [SerializeField]
    private bool _persistent = true;


    public static T Instance
    {
        get
        {
            // Optional. Read Singleton class (not templated one)
            /*if(quitting)
            {
                Debug.LogWarning($"[{nameof(Singleton)}<{typeof(T)}>] Instance will not be returned because application is quitting.");
                return null;
            }*/
            lock(Lock)
            {
                if (_instance != null)
                    return _instance;

                T[] instances = FindObjectsOfType<T>();
                int count = instances.Length;

                if (count > 0)
                {
                    if (count != 1)
                    {
                        Debug.LogWarning($"[{nameof(Singleton<T>)}<{typeof(T)}>] There should never be more than one {nameof(Singleton<T>)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                        for (int i = 1; i < count; i++)
                            Destroy(instances[i]);
                    }
                    return _instance = instances[0];
                }

                Debug.Log($"[{nameof(Singleton<T>)}<{typeof(T)}>] An instance is needed in the scene and no existing instances were found, so a new instance will be created.");
                return _instance = new GameObject($"({nameof(Singleton<T>)}){typeof(T)}").AddComponent<T>();
            }
        }
    }

    protected virtual void Awake()
    {
        if(_persistent)
            DontDestroyOnLoad(gameObject);
        _ = Instance;
    }

}

// Optional. Need to set Singleton<T> to inherit this instead of MonoBehaviour
/*public abstract class Singleton : MonoBehaviour
{
    public static bool quitting { get; private set; }

    private void OnApplicationQuit()
    {
        quitting = true;
    }
}*/