using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class StorageEditor
{
    static string storeDirectory = Application.persistentDataPath + "/Data";
    [MenuItem("MyTools/Clear All Data")]
    static void ClearData()
    {
        PlayerPrefs.DeleteAll();
        if (Directory.Exists(storeDirectory))
        {
            Directory.Delete(storeDirectory, true);
        }
        Debug.Log("Clear done!");
    }
}
