using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager {

    private static Dictionary<string, List<Action<object>>> m_eventDic = new Dictionary<string, List<Action<object>>>();

    public static void RegisterEvent(string _key, Action<object> _obj)
    {
        if (m_eventDic.ContainsKey(_key))
        {
            if (m_eventDic[_key].Contains(_obj))
                Debug.LogError("NO REPETITION");
            else
                m_eventDic[_key].Add(_obj);
        }
        else
        {
            m_eventDic.Add(_key, new List<Action<object>>());
            m_eventDic[_key].Add(_obj);
        }
    }

    public static void SendEvent(string _key, object _obj)
    {
        if (m_eventDic.ContainsKey(_key))
        {
            if (m_eventDic[_key].Count > 0)
            {
                for (int i = 0; i < m_eventDic[_key].Count; i++)
                {
                    Action<object> t_eventAction = m_eventDic[_key][i];
                    t_eventAction(_obj);
                }
            }
            else
            {
                Debug.LogError("INVALID KEY");
            }
        }
        else
        {
            Debug.LogError("INVALID KEY");
        }
    }

    public static void RemoveEvent(string _key, Action<object> _obj)
    {
        if (m_eventDic.ContainsKey(_key))
        {
            if (m_eventDic[_key].Contains(_obj))
                m_eventDic[_key].Remove(_obj);
            else
                Debug.LogError("INVALID KEY");
        }
        else
        {
            Debug.LogError("INVALID KEY");
        }
    }

    public static void RemoveAllEvent(string _key)
    {
        if (m_eventDic.ContainsKey(_key))
            m_eventDic.Remove(_key);
        else
            Debug.LogError("INVALID KEY");
    }

    public static void ClearAllRegister()
    {
        m_eventDic.Clear();
    }
}
