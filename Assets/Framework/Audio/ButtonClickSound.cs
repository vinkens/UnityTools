using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSound : MonoBehaviour
{
    public AudioClip clickSound;
    private void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => AudioManager.PlaySound(clickSound));
    }
}
