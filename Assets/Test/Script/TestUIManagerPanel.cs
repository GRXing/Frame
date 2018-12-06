using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIManagerPanel : UIBase {

    public UnityEngine.UI.Text Text;

    public void SetText(string _msg)
    {
        Text.text = _msg;
    }
}
