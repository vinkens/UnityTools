using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityEx
{

    public static void PlaySound(this MonoBehaviour com, AudioClip clip)
    {
        {
            AudioSource audioSource = com.GetComponent<AudioSource>();
            if (null == audioSource)
            {
                audioSource = com.gameObject.AddComponent<AudioSource>();
            }
            audioSource.PlayOneShot(clip);
        }
    }

}
