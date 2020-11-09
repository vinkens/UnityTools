using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UITools
{
    public static void LimitArea(RectTransform rt, RectTransform area)
    {
        float minWidth = (-area.rect.width / 2 + rt.rect.width / 2) / 100;
        float maxWidth = -minWidth;
        float minHeight = (-area.rect.height / 2 + rt.rect.height / 2) / 100;
        float maxHeight = -minHeight;

        float rangeX = Mathf.Clamp(rt.position.x, minWidth, maxWidth);
        float rangeY = Mathf.Clamp(rt.position.y, minHeight, maxHeight);

        rt.position = new Vector3(rangeX, rangeY, 0);
    }
}
