using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MsgListenerModule<UIManager>
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    public Transform Root { get; private set; }
    public Transform WindowRoot { get; private set; }

    private Transform fullScreenMask;
    private Dictionary<UILayer, BasePanel> activePanelDict = new Dictionary<UILayer, BasePanel>();


    public void Init(Transform root)
    {
        this.Root = root;
        WindowRoot = root.GetComponentInChildren<Canvas>().transform;
        fullScreenMask = root.FindChildRecursively("FullScreenMask");
    }

    public T Get<T>() where T : BasePanel
    {
        return Root.GetComponentInChildren<T>(true);
    }

    public void ShowPanel<T>(float animTime = -1) where T : BasePanel
    {
        BasePanel panel = Get<T>();
        ShowPanel(panel, animTime);
    }

    public void ShowPanel(BasePanel panel, float animTime = -1)
    {
        if (null == panel)
        {
            return;
        }
        if (activePanelDict.TryGetValue(panel.layer, out BasePanel activePanel))
        {
            activePanel.Show(false, animTime);
            activePanelDict[panel.layer] = panel;
        }
        else
        {
            activePanelDict.Add(panel.layer, panel);
        }
        panel.Show(true, animTime);
    }

    public void HidePanel<T>(float animTime = -1) where T : BasePanel
    {
        BasePanel panel = Get<T>();
        HidePanel(panel, animTime);
    }

    public void HidePanel(BasePanel panel, float animTime = -1)
    {
        panel.Show(false, animTime);
        if (activePanelDict.ContainsKey(panel.layer))
        {
            activePanelDict.Remove(panel.layer);
        }
    }

    public BasePanel HideSpecificPanel(UILayer layer, float animTime = -1)
    {
        BasePanel panel = null;
        if (activePanelDict.ContainsKey(layer))
        {
            panel = activePanelDict[layer];
            HidePanel(panel, animTime);
        }
        return panel;
    }

    public void ShowPopup<T>(float animTime = -1) where T : BasePanel
    {
        BasePanel panel = Get<T>();
        if (panel.layer != UILayer.Popup)
        {
            Debug.LogError("not a popup:" + typeof(T).ToString());
            return;
        }
        if (fullScreenMask != null)
        {
            fullScreenMask.gameObject.SetActive(true);
            fullScreenMask.transform.SetAsLastSibling();
        }
        panel.transform.SetAsLastSibling();
        ShowPanel(panel, animTime);
    }

    public void HidePopup<T>(float animTime = -1) where T : BasePanel
    {
        BasePanel panel = Get<T>();
        if (panel.layer != UILayer.Popup)
        {
            Debug.LogError("not a popup:" + typeof(T).ToString());
            return;
        }
        if (fullScreenMask != null)
        {
            fullScreenMask.gameObject.SetActive(false);
        }
        HidePanel(panel, animTime);
    }
    public Transform Find(string name)
    {
        return Root.FindChildRecursively(name);
    }

    public GameObject CreateUIObj(GameObject obj)
    {
        return Object.Instantiate(obj, WindowRoot);
    }
}
