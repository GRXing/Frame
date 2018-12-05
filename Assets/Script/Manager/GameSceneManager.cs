using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    public static GameSceneManager Instance;

    [SerializeField]
    ScenePrefabs[] m_scenePrefabs;

    void Awake()
    {
        Instance = this;
        Load();
    }

    void Load()
    {
        string t_sceneName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < m_scenePrefabs.Length; i++)
        {
            if (t_sceneName.Equals(m_scenePrefabs[i].SceneName))
            {
                for (int m = 0; m < m_scenePrefabs[i].Prefabs.Length; m++)
                {
                    GameObject t_manager = Instantiate(m_scenePrefabs[i].Prefabs[m]);
                    if (m_scenePrefabs[i].Prefabs[m].layer == LayerMask.NameToLayer("UI"))
                    {
                        t_manager.transform.SetParent(UIManager.Instance.UIParent,false);
                    }
                    else
                        t_manager.transform.SetParent(this.transform,false);
                    t_manager.name = m_scenePrefabs[i].Prefabs[m].name;
                }
                break;
            }
        }
    }
}
