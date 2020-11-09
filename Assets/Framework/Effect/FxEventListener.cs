using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FxEventListener : MonoBehaviour
{
    public UnityEvent m_OnFxStart;
    public UnityEvent m_OnFirstItemEnd;
    public FxEvent m_OnItemEnd;
    public UnityEvent m_OnFxEnd;
    public void EmitFxStartEvent()
    {
        m_OnFxStart?.Invoke();
    }
    public void EmitFirstItemEndEvent()
    {
        m_OnFirstItemEnd?.Invoke();
    }

    public void EmitItemEndEvent(int itemIndex)
    {
        m_OnItemEnd?.Invoke(itemIndex);
    }

    public void EmitFxEndEvent()
    {
        m_OnFxEnd?.Invoke();
    }

    [System.Serializable]
    public class FxEvent : UnityEvent<int>
    {

    }
}
