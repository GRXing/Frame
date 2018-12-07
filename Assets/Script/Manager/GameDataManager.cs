using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour {

    public static GameDataManager Instance;

    private GameData m_gameData;
    private Hashtable m_saveDataHash;
    public Hashtable SaveDataHash { get { return m_saveDataHash; } }

    void Awake()
    {
        Instance = this;
        m_gameData = new GameData();
        m_saveDataHash = new Hashtable();
        SaveGameManager.LoadData();
    }

#if UNITY_EDITOR
    public int TestDataInt
    {
        set 
        {
            m_gameData.TestDataInt = value;
            SaveToLocal("TestDataInt", m_gameData.TestDataInt);
        }
        get { return m_gameData.TestDataInt; }
    }

    public bool TestDataBool
    {
        set 
        { 
            m_gameData.TestDataBool = value;
            SaveToLocal("TestDataBool", m_gameData.TestDataBool);
        }
        get { return m_gameData.TestDataBool; }
    }

    public string TestDataString
    {
        set 
        {
            m_gameData.TestDataString = value;
            SaveToLocal("TestDataString", m_gameData.TestDataString);
        }
        get { return m_gameData.TestDataString; }
    }
#endif

    public void SaveToLocal(string _key, object _value)
    {
        m_saveDataHash[_key] = _value;
        SaveGameManager.SaveData(m_saveDataHash);
    }

    public void LoadSaveData(Hashtable _hash)
    {
        m_saveDataHash = _hash;
        //Merge with m_gameData
#if UNITY_EDITOR
        if (_hash.GetInt("TestDataInt") > m_gameData.TestDataInt)
            m_gameData.TestDataInt = _hash.GetInt("TestDataInt");
        if (_hash.GetBool("TestDataBool"))
            m_gameData.TestDataBool = _hash.GetBool("TestDataBool");
        if (_hash.GetString("TestDataString") != null)
            m_gameData.TestDataString = _hash.GetString("TestDataString");
#endif
    }

    public void ResetAllData()
    {
        m_gameData = new GameData();
        m_saveDataHash = new Hashtable();
    }

}
