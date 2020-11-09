using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageAnimation : MonoBehaviour
{
    public Image image;
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

    public void Reset()
    {
        image.sprite = sprites[0];
    }

    public void Play()
    {
        StartCoroutine(_Play());
    }
    IEnumerator _Play()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            image.sprite = sprites[i];
            yield return new WaitForSeconds(interval);
        }
    }
}
