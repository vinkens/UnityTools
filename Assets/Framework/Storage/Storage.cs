using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Storage
{
    static List<Storage> allStorageList = new List<Storage>();

    private IPersistable persistableObj;
    private string saveFileName;
    public Storage(IPersistable persistableObj, string saveFileName)
    {
        this.persistableObj = persistableObj;
        this.saveFileName = saveFileName;
        allStorageList.Add(this);
    }
    public string SavePath
    {
#if UNITY_EDITOR

        get
        {
            string directory = Path.Combine(Application.persistentDataPath, "Data");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return Path.Combine(directory, saveFileName);
        }
#else
         get => Path.Combine(Application.persistentDataPath, saveFileName);
#endif
    }

    public bool HasData(string fileName)
    {
        return File.Exists(SavePath);
    }


    public void Save()
    {
        //Debug.Log("save data:" + saveFileName + ", version:" + persistableObj.Version);
        using (var writer = new BinaryWriter(File.Open(SavePath, FileMode.Create)))
        {
            writer.Write(persistableObj.Version);
            persistableObj.Save(new GameDataWriter(writer));
        }
    }

    public void Load()
    {
        //Debug.Log("load data:" + saveFileName);
        if (!HasData(saveFileName))
        {
            persistableObj.Init();
        }
        else
        {
            using (var reader = new BinaryReader(File.Open(SavePath, FileMode.Open)))
            {
                persistableObj.Load(new GameDataReader(reader, reader.ReadInt32()));
            }
        }
    }

    public static void SaveAll()
    {
        foreach (Storage storage in allStorageList)
        {
            storage.Save();
        }
    }
}
