using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class FileSaveLoad : IDataSaveLoad
{
    public void Clear(string filename)
    {
        string path = UnityEngine.Application.persistentDataPath + "/" + filename + ".gamedata";
        File.Delete(path);
    }

    public void Load<T>(string filename, ref T data)
    {
        string path = UnityEngine.Application.persistentDataPath + "/" + filename + ".gamedata";
        //Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            data = (T)formatter.Deserialize(stream);
            stream.Close();
        }
    }

    public void Save(string filename, object data)
    {
        string path = UnityEngine.Application.persistentDataPath + "/" + filename + ".gamedata";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
}
