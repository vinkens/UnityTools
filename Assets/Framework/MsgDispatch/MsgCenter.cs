using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventConst
{
    //data
    public const string EVENT_GET_FRUIT = "EVENT_GET_FRUIT";

    //audio
    public const string EVENT_MUSIC_CHANGE = "EVENT_MUSIC_CHANGE";
    public const string EVENT_SOUND_CHANGE = "EVENT_SOUND_CHANGE";

    //ui
    public const string EVENT_SHOW_MASK = "EVENT_SHOW_MASK";
    public const string EVENT_ONCLICK_MASK = "EVENT_ONCLICK_MASK";
    public const string EVENT_SLOT_ON_SELECTED = "EVENT_SLOT_ON_SELECTED";

    //game
    public const string EVENT_LEVEL_COMPLETE = "EVENT_LEVEL_COMPLETE";
    public const string EVENT_LEVEL_CREATE = "EVENT_LEVEL_CREATE";
    public const string EVENT_LEVEL_START = "EVENT_LEVEL_START";
}

public class MsgCenter
{
    private static List<IMsgListener> m_ModuleList = new List<IMsgListener>();

    /// <summary>
    /// 全局广播
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="args"></param>
    public static void BroadCastMessage(string eventName, params object[] args)
    {
        for (int i = 0; i < m_ModuleList.Count; i++)
        {
            IMsgListener module = m_ModuleList[i];
            module.Excute(eventName, args);
        }
    }

    public static void RegisterListener(IMsgListener listener)
    {
        if (!m_ModuleList.Contains(listener))
        {
            m_ModuleList.Add(listener);
        }
    }

    public static void RemoveListener(IMsgListener listener)
    {
        if (m_ModuleList.Contains(listener))
        {
            m_ModuleList.Remove(listener);
        }
    }
}
