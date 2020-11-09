using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class AddSounds
{
    static readonly string uiPrefabFolder = "Assets/Prefabs/UIPanels";
    static readonly string audioClipFolder = "Assets/AudioClips";//音效资源文件夹路径

    static readonly string buttonClickClipPath = audioClipFolder + "/button_click.wav";
    static readonly string popOnEnableClipPath = audioClipFolder + "/panel_open.wav";
    static readonly string popOnDisableClipPath = audioClipFolder + "/panel_close.wav";

    [MenuItem("MyTools/Add Button Click Sounds")]
    public static void AddButtonClickSounds()
    {
        string[] uiPrefabGuids = AssetDatabase.FindAssets("t:Object", new string[] { uiPrefabFolder });
        for (int i = 0; i < uiPrefabGuids.Length; i++)
        {
            string uiPrefabPath = AssetDatabase.GUIDToAssetPath(uiPrefabGuids[i]);
            GameObject uiPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(uiPrefabPath);
            Button[] btns = uiPrefab.GetComponentsInChildren<Button>(true);
            for (int j = 0; j < btns.Length; j++)
            {
                Button btn = btns[j];
                ButtonClickSound buttonClickSound = btn.GetComponent<ButtonClickSound>();
                if (null == buttonClickSound)
                {
                    buttonClickSound = btn.gameObject.AddComponent<ButtonClickSound>();
                    buttonClickSound.clickSound = AssetDatabase.LoadAssetAtPath<AudioClip>(buttonClickClipPath);
                    EditorUtility.SetDirty(btn);
                }
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }


    [MenuItem("MyTools/Add Popup Sounds")]
    public static void AddPopupSounds()
    {
        string[] uiPrefabGuids = AssetDatabase.FindAssets("t:Object", new string[] { uiPrefabFolder });
        for (int i = 0; i < uiPrefabGuids.Length; i++)
        {
            string uiPrefabPath = AssetDatabase.GUIDToAssetPath(uiPrefabGuids[i]);
            GameObject uiPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(uiPrefabPath);

            BasePanel basePanel = uiPrefab.GetComponent<BasePanel>();
            if (null == basePanel)
            {
                Debug.LogError("there is no basepanel script attached on ui gameobject:" + uiPrefab.name);
                continue;
            }

            AudioOnPopup audioOnPopup = uiPrefab.GetComponent<AudioOnPopup>();
            if (null == audioOnPopup && basePanel.layer == UILayer.Popup)
            {
                audioOnPopup = uiPrefab.AddComponent<AudioOnPopup>();
                audioOnPopup.clipOpen = AssetDatabase.LoadAssetAtPath<AudioClip>(popOnEnableClipPath);
                audioOnPopup.clipClose = AssetDatabase.LoadAssetAtPath<AudioClip>(popOnDisableClipPath);
                EditorUtility.SetDirty(uiPrefab);
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
