using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
public class UISwitch : MonoBehaviour
{

    public event System.Action<bool> EventChange;
    public Button button;
    public GameObject imageOn;
    public GameObject imageOff;
    public bool isOn;

    // Use this for initialization
    void Awake()
    {
        if (null == button)
        {
            button = GetComponent<Button>();
        }
        button.onClick.AddListener(Button_OnClick);
        SetOn(isOn);
    }

    void Button_OnClick()
    {
        SetOn(!isOn);
        EventChange?.Invoke(isOn);
    }

    public void SetOn(bool isOn)
    {
        this.isOn = isOn;
        imageOn.SetActive(isOn);
        imageOff.SetActive(!isOn);
    }


}
