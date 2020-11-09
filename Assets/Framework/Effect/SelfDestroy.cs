using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public bool awake = true;
    public float delay;
    private void Start()
    {
        if (awake)
        {
            Destroy(gameObject, delay);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
