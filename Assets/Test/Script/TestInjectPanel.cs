using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInjectPanel : UIBase {

    public Button TestInject_Btn;
    [ForbidInject]
    public Text TestInject_Text;
    public Image TestInject_Image;

    void Awake()
    {
        
    }

    protected override void OnDestroy()
    {
        
    }
}
