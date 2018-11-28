using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager {

    private static Dictionary<string, List<RegisterEventHandler>> m_eventDic = new Dictionary<string, List<RegisterEventHandler>>();

    public delegate void RegisterEventHandler(params object[] objs);

    /// <summary>
    /// 消息注册
    /// </summary>
    /// <param name="_key">事件ID</param>
    /// <param name="_func">相应事件函数</param>
    public static void RegisterEvent(string _key, RegisterEventHandler _func)
    {
        if (m_eventDic.ContainsKey(_key))
        {
            if (m_eventDic[_key].Contains(_func))
                Debug.LogError("NO REPETITION");
            else
                m_eventDic[_key].Add(_func);
        }
        else
        {
            m_eventDic.Add(_key, new List<RegisterEventHandler>());
            m_eventDic[_key].Add(_func);
        }
    }

    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="_key">事件ID</param>
    /// <param name="_obj">本次事件携带的参数</param>
    public static void SendEvent(string _key, params object[] _obj)
    {
        
        if (m_eventDic.ContainsKey(_key))
        {
            if (m_eventDic[_key].Count > 0)
            {
                for (int i = 0; i < m_eventDic[_key].Count; i++)
                {
                    RegisterEventHandler t_eventAction = m_eventDic[_key][i];
                    t_eventAction(_obj);
                }
            }
            else
                Debug.LogError("INVALID KEY");
        }
        else
            Debug.LogError("INVALID KEY");
    }

    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="_key">事件ID</param>
    /// <param name="_func">需要移除事件对应的函数</param>
    public static void RemoveEvent(string _key, RegisterEventHandler _func)
    {
        if (m_eventDic.ContainsKey(_key))
        {
            if (m_eventDic[_key].Contains(_func))
                m_eventDic[_key].Remove(_func);
            else
                Debug.LogError("INVALID KEY");
        }
        else
            Debug.LogError("INVALID KEY");
    }

    /// <summary>
    /// 移除本事件ID下全部函数
    /// </summary>
    /// <param name="_key">事件ID</param>
    public static void RemoveAllEvent(string _key)
    {
        if (m_eventDic.ContainsKey(_key))
            m_eventDic.Remove(_key);
        else
            Debug.LogError("INVALID KEY");
    }

    /// <summary>
    /// 清除所有事件与相关函数
    /// </summary>
    public static void ClearAllRegister()
    {
        m_eventDic.Clear();
    }
}
