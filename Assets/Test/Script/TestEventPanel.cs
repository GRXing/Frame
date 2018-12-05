using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventPanel : UIBase{

    public void OnRegisterEventDelegate()
    {
        Debug.Log("register one");
        EventManager.RegisterEvent(EventKey.TestRegisterOne, TestOneCallback);
    }

    void TestOneCallback(object[] _obj)
    {
        Debug.LogError(_obj.Length);
    }

    public void OnRegisterOtherEventDelegate()
    {
        Debug.Log("register two");
        EventManager.RegisterEvent(EventKey.TestRegisterOne, TestTwoCallback);
    }

    void TestTwoCallback(object[] _obj)
    {
        if (_obj != null)
        {
            for (int i = 0; i < _obj.Length;i++ )
                Debug.LogError(_obj[i].GetType() + " " + _obj[i]);
        }
        else
        {
            Debug.LogError("callback is null");
        }
    }

    void TestDelegate(string arg1, int arg2, float arg3)
    {

    }

    public void OnSendEventDelegate()
    {
        Debug.Log("send event");
        EventManager.SendEvent(EventKey.TestRegisterOne,11524,"asd1254",this);
    }

    public void OnRemoveEventDelegate()
    {
        Debug.Log("remove event");
        EventManager.RemoveEvent(EventKey.TestRegisterOne, TestOneCallback);
        //EventManager.RemoveAllEvent(EventKey.TestRegisterOne);
        //EventManager.ClearAllRegister();
    }
}
