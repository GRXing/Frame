using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager {

    private static Dictionary<string, List<object>> m_eventDic = new Dictionary<string, List<object>>();

    public static void RegisterEvent(string _key, Action<object> _action)
    {
        RegisterObject(_key, _action);
    }

    static void RegisterObject(string _key, object _obj)
    {
        if (m_eventDic.ContainsKey(_key))
        {
            List<object> t_obj = m_eventDic[_key];
            if (t_obj != null)
            {
                if (t_obj.Contains(_obj))
                    Debug.LogError("NO REPETITION");
                else
                    m_eventDic[_key].Add(_obj);
            }
            else
            {
                m_eventDic.Add(_key, new List<object>());
                m_eventDic[_key].Add(_obj);
            }
        }
        else
        {
            m_eventDic.Add(_key, new List<object>());
            m_eventDic[_key].Add(_obj);
        }
    }

    public static void SendEvent(string _key, object _obj)
    {
        if (m_eventDic.ContainsKey(_key))
        {
            List<object> t_obj = m_eventDic[_key];
            if (t_obj != null)
            {
                for (int i = 0; i < t_obj.Count; i++)
                {
                    Action<object> t_eventAction = t_obj[i] as Action<object>;
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

}
