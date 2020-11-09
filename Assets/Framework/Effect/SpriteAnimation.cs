using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] sprites;
    public float interval = 0.1f;

    public bool playOnAwake;

    private void Awake()
    {
        if (playOnAwake)
        {
            Play();
        }
    }
    public void OnValidate()
    {
        sr.sprite = sprites[0];
    }

    public void Play()
    {
        StartCoroutine(_Play());
    }
    IEnumerator _Play()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sr.sprite = sprites[i];
            yield return new WaitForSeconds(interval);
        }
    }
}
