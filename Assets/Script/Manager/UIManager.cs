using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    private static Dictionary<string, UIBase> m_uiDic = new Dictionary<string, UIBase>();

    [SerializeField]GameObject m_uiParentPrefab;

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
        if (m_uiDic.ContainsKey(_panelPath))
        {
            return m_uiDic[_panelPath];
        }

        UIBase t_base = Resources.Load<UIBase>(_panelPath);
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

}
