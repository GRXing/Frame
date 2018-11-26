using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanel : MonoBehaviour {

    public void OnRegisterEventDelegate()
    {
        Debug.Log("register one");
        EventManager.RegisterEvent(EventKey.TestRegisterOne, TestOneCallback);
    }

    void TestOneCallback(object _obj)
    {
        string t_msg = _obj as string;
        Debug.LogError(t_msg);
    }

    public void OnRegisterOtherEventDelegate()
    {
        Debug.Log("register two");
        EventManager.RegisterEvent(EventKey.TestRegisterOne, TestTwoCallback);
    }

    void TestTwoCallback(object _obj)
    {
        if (_obj != null)
        {
            int t_msg = (int)_obj;
            Debug.LogError(t_msg);
        }
        else
        {
            Debug.LogError("callback is null");
        }
    }

    public void OnSendEventDelegate()
    {
        Debug.Log("send event");
        EventManager.SendEvent(EventKey.TestRegisterOne,null);
    }

    public void OnRemoveEventDelegate()
    {
        Debug.Log("remove event");
        EventManager.RemoveEvent(EventKey.TestRegisterOne, TestOneCallback);
        //EventManager.RemoveAllEvent(EventKey.TestRegisterOne);
        //EventManager.ClearAllRegister();
    }
}
