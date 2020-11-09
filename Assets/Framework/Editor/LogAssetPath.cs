using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LogAssetPath
{
    [MenuItem("Tools/Log Selected Asset Path")]
    static void LogSelectedAssetPath()
    {
        Debug.Log(AssetDatabase.GetAssetPath(Selection.activeObject));
    }
}
