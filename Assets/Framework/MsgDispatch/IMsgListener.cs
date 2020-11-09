using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMsgListener
{
    void Excute(string eventName,params object[] args);
}
