using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    private static Dictionary<string, UIBase> m_uiDic = new Dictionary<string, UIBase>();

    [SerializeField]GameObject m_uiParentPrefab;

    public static int UICurrentSiblineIndex;

    private Transform m_uiParent;
    public Transform UIParent
    {
        get
        {
            if (m_uiParent == null)
            {
                Canvas t_canvas = GameObject.FindObjectOfType<Canvas>();
                if (t_canvas != null)
                {
                    m_uiParent = t_canvas.transform;
                }
                else
                {
                    m_uiParent = Instantiate(m_uiParentPrefab).transform;
                    m_uiParent.name = "UIParent";
                }
            }
            return m_uiParent;
        }
    }

    void Awake()
    {
        UICurrentSiblineIndex = 0;
        Instance = this;
    }

    public UIBase OpenPanel(string _panelPath)
    {
        UIBase t_base = GetPanel(_panelPath);
        if (t_base != null)
            t_base.Show();
        return t_base;
    }

    public UIBase GetPanel(string _panelPath)
    {
        UIBase t_base = null;
        if (m_uiDic.ContainsKey(_panelPath))
        {
            t_base = m_uiDic[_panelPath];
            if (t_base == null)
            {
                m_uiDic.Remove(_panelPath);
            }
            else
            {
                return m_uiDic[_panelPath];
            }
        }

        t_base = Resources.Load<UIBase>(_panelPath);
        if (t_base != null)
        {
            t_base = Instantiate<UIBase>(t_base);
            t_base.transform.SetParent(UIParent.transform,false);
            m_uiDic.Add(_panelPath, t_base);
            t_base.Hide();
        }
        else
            Debug.LogError("\"" + _panelPath+"\" is null");

        return t_base;
    }

    public UIBase ClosePanel(string _panelPath)
    {
        UIBase t_base = null;
        if (m_uiDic.ContainsKey(_panelPath))
        {
            t_base = m_uiDic[_panelPath];
            if (t_base == null)
            {
                m_uiDic.Remove(_panelPath);
            }
            else
            {
                t_base.Hide();
            }
        }
        return t_base;
    }

    public static void ClearAllUI()
    {
        List<UIBase> t_list = new List<UIBase>(m_uiDic.Values);
        for (int i = 0; i < t_list.Count; i++)
        {
            Destroy(t_list[i].gameObject);
        }
        t_list.Clear();
        m_uiDic.Clear();
        UICurrentSiblineIndex = 0;
    }

}
