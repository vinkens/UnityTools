using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnPopup : MonoBehaviour
{
    public AudioClip clipOpen;
    public AudioClip clipClose;


    void OnEnable()
    {
        this.PlaySound(clipOpen);
    }

    void OnDisable()
    {
        this.PlaySound(clipClose);
    }
}
