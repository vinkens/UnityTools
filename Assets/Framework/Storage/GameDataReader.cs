using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataReader
{
    public int version;
    BinaryReader reader;
    public GameDataReader(BinaryReader reader, int version)
    {
        this.reader = reader;
        this.version = version;
    }

    public float ReadFloat()
    {
        return reader.ReadSingle();
    }

    public int ReadInt()
    {
        return reader.ReadInt32();
    }

    public long ReadLong()
    {
        return reader.ReadInt64();
    }

    public Quaternion ReadQuaternion()
    {
        Quaternion value;
        value.x = reader.ReadSingle();
        value.y = reader.ReadSingle();
        value.z = reader.ReadSingle();
        value.w = reader.ReadSingle();
        return value;
    }

    public Vector3 ReadVector3()
    {
        Vector3 value;
        value.x = reader.ReadSingle();
        value.y = reader.ReadSingle();
        value.z = reader.ReadSingle();
        return value;
    }

    public Color ReadColor()
    {
        Color c;
        c.r = reader.ReadSingle();
        c.g = reader.ReadSingle();
        c.b = reader.ReadSingle();
        c.a = reader.ReadSingle();
        return c;
    }

    public List<int> ReadIntList()
    {
        int count = ReadInt();
        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
        {
            list.Add(ReadInt());
        }
        return list;
    }
}
