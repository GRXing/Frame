using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class UIBase : MonoBehaviour {

    public void Inject()
    {
        Type t_type = this.GetType();
        //Debug.LogError(t_type);
        FieldInfo[] t_fields = t_type.GetFields();
        for (int i = 0; i < t_fields.Length; i++)
        {
            //Debug.LogError(t_fields[i].Name);
            Transform t_variable = transform.SearchChild(t_fields[i].Name);
            if (t_variable != null)
            {
                Component t_component = t_variable.GetComponent(t_fields[i].FieldType);
                t_fields[i].SetValue(this,t_component);
            }
        }
    }
}
