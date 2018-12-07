using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    public static GameSceneManager Instance;

    [SerializeField]
    ScenePrefabs[] m_scenePrefabs;

    public string CurrentSceneName
    {
        get { return SceneManager.GetActiveScene().name; }
    }

    void Awake()
    {
        Instance = this;
        SceneManager.activeSceneChanged += ChangeSceneCallback;
    }

    void ChangeSceneCallback(Scene _src, Scene _des)
    {
        Load();
    }

    void Load()
    {
        for (int i = 0; i < m_scenePrefabs.Length; i++)
        {
            if (CurrentSceneName.Equals(m_scenePrefabs[i].SceneName))
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
        UIManager.UICurrentSiblineIndex = 0;
    }
#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TestEvent");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TestInject");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TestLaunch");
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
             
           TestUIManagerPanel _panel = UIManager.Instance.GetPanel(UIPath.TestPanel1) as TestUIManagerPanel;
           _panel.SetText("test get ui");
           _panel.Show();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            UIManager.Instance.OpenPanel(UIPath.TestPanel2);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            UIManager.Instance.OpenPanel(UIPath.TestPanel3);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            UIManager.Instance.OpenPanel(UIPath.TestPanel4);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            UIManager.Instance.OpenPanel(UIPath.TestPanel5);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            UIManager.Instance.ClosePanel(UIPath.TestPanel1);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            UIManager.Instance.ClosePanel(UIPath.TestPanel2);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.ClosePanel(UIPath.TestPanel3);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            UIManager.Instance.ClosePanel(UIPath.TestPanel4);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            UIManager.Instance.ClosePanel(UIPath.TestPanel5);
        }
    }
#endif
}
