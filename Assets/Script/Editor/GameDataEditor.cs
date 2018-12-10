using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
public class GameDataEditor : Editor {

    [MenuItem("Tools/ClearLocalData")]
    static void ClearData()
    {
        string _path = UnityEngine.Application.persistentDataPath;
        if (Directory.Exists(_path))
        {
            Directory.Delete(_path, true);
            UnityEngine.Debug.Log("GameData Clear Finish! ");
        }
    }
}
