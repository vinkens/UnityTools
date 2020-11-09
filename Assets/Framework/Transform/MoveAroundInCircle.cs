using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MoveAroundInCircle : MonoBehaviour
{
    public FillOrigin fillOrigin;
    public float radius;
    [Range(0, 1f)]
    public float Progress;
    public bool clockWise = false;
    private int degreeOffset;

    private void OnValidate()
    {
        switch (fillOrigin)
        {
            case FillOrigin.Top:
                degreeOffset = 0;
                break;
            case FillOrigin.Bottom:
                degreeOffset = -180;
                break;
            case FillOrigin.Left:
                degreeOffset = -90;
                break;
            case FillOrigin.Right:
                degreeOffset = 90;
                break;
        }
    }

    private void Start()
    {
        OnValidate();
    }
    private void Update()
    {
        float radians = (Progress * 360f - degreeOffset) * Mathf.Deg2Rad;
        Vector2 x = Vector2.right * Mathf.Sin(radians);
        Vector2 y = Vector2.up * Mathf.Cos(radians);
        if (clockWise)
        {
            if ((int)fillOrigin <= 1)
                transform.localPosition = ((clockWise ? 1 : -1) * x + y) * radius;
            else
                transform.localPosition = (x + (clockWise ? 1 : -1) * y) * radius;
        }
        else
        {
            transform.localPosition = (x + y) * radius;
        }
    }

    public enum FillOrigin
    {
        Top,
        Bottom,
        Left,
        Right
    }
}
