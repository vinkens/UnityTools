using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton : MonoBehaviour
{
    public bool dontDestroOnLoad;
    public static MonoSingleton Instance;

    protected virtual void Awake()
    {
        Instance = this;
        if (dontDestroOnLoad)
        {
            DontDestroyOnLoad(this);
        }
    }
}
