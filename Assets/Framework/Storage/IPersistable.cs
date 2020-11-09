using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPersistable
{
    int Version { get; }
    void Init();
    void Load(GameDataReader reader);
    void Save(GameDataWriter writer);
}
