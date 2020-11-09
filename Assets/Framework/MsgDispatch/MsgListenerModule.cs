using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgListenerModule<T> : IMsgListener where T : new()
{
    protected Dictionary<string, List<IMsgListener>> m_ListenerDict = new Dictionary<string, List<IMsgListener>>();

    public MsgListenerModule()
    {
        MsgCenter.RegisterListener(this);
    }

    ~MsgListenerModule()
    {
        MsgCenter.RemoveListener(this);
    }
    public virtual void Excute(string eventName, params object[] args)
    {
        if (!m_ListenerDict.TryGetValue(eventName, out List<IMsgListener> listenerList))
        {
            return;
        }

        for (int i = 0; i < listenerList.Count; i++)
        {
            if (listenerList[i] != this)
            {
                listenerList[i].Excute(eventName, args);
            }
        }
    }
    public void Bind(string eventName)
    {
        AddListener(eventName, this);
    }
    public void AddListener(string eventName, IMsgListener listener)
    {
        if (string.IsNullOrEmpty(eventName) || null == listener)
        {
            return;
        }
        if (!m_ListenerDict.TryGetValue(eventName, out List<IMsgListener> list))
        {
            list = new List<IMsgListener>();
            m_ListenerDict.Add(eventName, list);
        }
        list.Add(listener);
    }

    public void AddListener(string[] eventNames, IMsgListener listener)
    {
        for (int i = 0; i < eventNames.Length; i++)
        {
            AddListener(eventNames[i], listener);
        }
    }

}
