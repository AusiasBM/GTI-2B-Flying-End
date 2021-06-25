using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataSaveLoad
{
    void Clear(string keyname);
    void Load<T>(string keyname, ref T data);
    void Save(string keyname, object data);
}