using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITools : MonoBehaviour
{
    public static Rect GetRect(float xIndex, float yIndex)
    {
        float width = 200;
        float height = 80;
        float space = 20;
        return new Rect((width + space) * xIndex, 100 + (height + space) * yIndex, width, height);
    }
}
