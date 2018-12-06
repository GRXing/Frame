using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField]
    GameObject[] m_managerPrefabs;

    void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        Instance = this;
        
        for (int i = 0; i < m_managerPrefabs.Length; i++)
        {
            GameObject t_manager = Instantiate(m_managerPrefabs[i]);
            t_manager.transform.SetParent(this.transform, false);
            t_manager.name = m_managerPrefabs[i].name;
        }
    }

    public void ResetAllGameData()
    {
        EventManager.ClearAllRegister();
        UIManager.ClearAllUI();
    }

}
