using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataGroup<T>
{
    public List<T> data;
    public string name;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">PlayerPrefs存储用的字符串</param>
    /// <param name="defaultVal">默认值</param>
    public DataGroup(string name, List<T> defaultVal = null)
    {
        this.name = name;
        if (!TryGet(name, out data))
        {
            data = defaultVal;
        }
    }

    public void Save()
    {
        string str = JsonUtility.ToJson(this);
        DataGroup<T> temp = JsonUtility.FromJson<DataGroup<T>>(str);
        PlayerPrefs.SetString(name, str);
        PlayerPrefs.Save();
    }

    public static bool TryGet(string str_name, out List<T> storedData)
    {
        if (PlayerPrefs.HasKey(str_name))
        {
            string str = PlayerPrefs.GetString(str_name);
            DataGroup<T> group = JsonUtility.FromJson<DataGroup<T>>(str);
            storedData = group.data;
            return true;
        }
        else
        {
            storedData = null;
            return false;
        }
    }
}

[System.Serializable]
public class ReadOnlyDataGroup<T>
{
    public List<T> data;
}
