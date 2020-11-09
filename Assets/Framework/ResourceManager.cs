using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class ResourceManager
{
    private static Dictionary<string, Object> allAssetDict = new Dictionary<string, Object>();
    public static string LoadData(string fileName)
    {
        TextAsset textAsset = Load<TextAsset>(Path.Combine("Data", fileName));
        return textAsset.text;
    }

    public static AudioClip LoadAudioClip(string fileName)
    {
        return Load<AudioClip>("AudioClips/" + fileName);
    }

    public static T Load<T>(string path) where T : Object
    {
        if (!allAssetDict.TryGetValue(path, out Object asset))
        {
            asset = Resources.Load<T>(path);
            allAssetDict.Add(path, asset);
        }
        return asset as T;
    }
}
