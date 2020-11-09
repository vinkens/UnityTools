using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformEx 
{
    public static Transform FindChildRecursively(this Transform parent, string childName)
    {
        Transform child = parent.Find(childName);
        if (child != null)
        {
            return child;
        }
        if (parent.childCount == 0)
        {
            return null;
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            child = parent.GetChild(i);
            child = child.FindChildRecursively(childName);
            if (child != null)
            {
                return child;
            }
        }
        return null;
    }
}
