using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UILayer
{
    Common,
    Second,
    Popup,
    Always
}
public class BasePanel : MonoBehaviour
{
    public UILayer layer;
    public void Show(bool show, float animTime = -1)
    {
        if (show)
        {
            OnShow();
            //UITween[] uITweens = GetComponentsInChildren<UITween>();
            //for (int i = 0; i < uITweens.Length; i++)
            //{
            //    uITweens[i].PlayForward(animTime);
            //}
        }
        else
        {
            //UITween[] uITweens = GetComponentsInChildren<UITween>();
            //for (int i = 0; i < uITweens.Length; i++)
            //{
            //    uITweens[i].PlayBackwards(animTime);
            //}
            OnHide();
        }
    }

    protected virtual void OnShow()
    {
        gameObject.SetActive(true);
    }

    protected virtual void OnHide()
    {
        gameObject.SetActive(false);
    }
}
