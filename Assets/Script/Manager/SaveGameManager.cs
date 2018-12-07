using System.Collections;
using UnityEngine;
using System;
using System.IO;
using System.Text;
/// <summary>
/// 获取本地数据
/// </summary>
public class SaveGameManager {

    private static string PersistentDataPath
    {
        get{ return Path.Combine(Application.persistentDataPath, "SaveData.json");}
    }

    public static void SaveData(Hashtable _hash)
    {
        if (_hash == null)
        {
            Debug.LogError("save data fail");
            return;
        }

        byte[] bytes = AES.AESEncrypt(JsonTools.jsonEncode(_hash));
        using (FileStream fs = new FileStream(PersistentDataPath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            if (fs != null)
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
                fs.Dispose();
            }
            //Debug.Log("encrypt: " + bytes.Length + "  code: " + Encoding.UTF8.GetString(bytes));
        }
        //upload clould "Convert.ToBase64String(bytes)"
    }

    public static void LoadData()
    {
        if (!File.Exists(PersistentDataPath))
        {
            Debug.Log("cannot load save data, file doesn't exist: " + PersistentDataPath);
            return;
        }
        LoadLocal(PersistentDataPath);
    }

    private static void LoadLocal(string _path)
    {
        using (FileStream fs = new FileStream(_path, FileMode.Open, FileAccess.Read))
        {
            if (fs != null)
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                //Debug.Log("encrypt: " + bytes.Length + " code: " + Encoding.UTF8.GetString(bytes));
                GameDataManager.Instance.LoadSaveData(JsonTools.jsonDecode(AES.AESDecrypt(bytes)) as Hashtable);
                fs.Flush();
                fs.Dispose();
                Debug.Log("load data finish");
            }
        }
    }
}
