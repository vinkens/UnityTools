using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtil
{

    public static List<T> FromJsonArray<T>(string jsonText)
    {
        List<T> list = new List<T>();

        JSONObject joArray = new JSONObject(jsonText);
        List<JSONObject> joList = joArray.list;
        for (int i = 0; i < joList.Count; i++)
        {
            JSONObject jo = joList[i];
            string objText = jo.ToString();
            T obj = JsonUtility.FromJson<T>(objText);
            list.Add(obj);
        }
        return list;
    }
    public static List<int> FromIntArray(string jsonText)
    {
        List<int> list = new List<int>();
        JSONObject jarray = new JSONObject(jsonText);
        for (int i = 0; i < jarray.Count; i++)
        {
            string valueText = jarray[i].ToString();
            int value = int.Parse(valueText);
            list.Add(value);
        }
        return list;
    }


    public static string ToIntArray(List<int> list)
    {

        JSONObject jarray = JSONObject.Create(JSONObject.Type.ARRAY);
        for (int i = 0; i < list.Count; i++)
        {
            jarray.Add(list[i]);
        }
        string jsonText = jarray.ToString();
        return jsonText;
    }


    public static string ToObjectArray<T>(List<T> list)
    {
        JSONObject jarray = JSONObject.Create(JSONObject.Type.ARRAY);
        for (int i = 0; i < list.Count; i++)
        {
            string json = JsonUtility.ToJson(list[i]);
            jarray.Add(new JSONObject(json));
        }
        string jsonText = jarray.ToString();
        return jsonText;
    }
}
