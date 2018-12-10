using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public abstract class UIBase : MonoBehaviour {

    public void Inject()
    {
        FieldInfo[] t_fields = this.GetType().GetFields();
        for (int i = 0; i < t_fields.Length; i++)
        {
            object[] t_objs = t_fields[i].GetCustomAttributes(typeof(ForbidInject), true);
            if (t_objs.Length > 0)
                continue;

            Transform t_variable = transform.SearchChild(t_fields[i].Name);
            if (t_variable != null)
            {
                Component t_component = t_variable.GetComponent(t_fields[i].FieldType);
                t_fields[i].SetValue(this,t_component);
            }
        }
    }

    public virtual void Show()
    {
        if (!this.gameObject.activeSelf)
        {
            if (UIManager.UICurrentSiblineIndex == 0)
                UIManager.UICurrentSiblineIndex = UIManager.Instance.UIParent.childCount - 1;
            else
                UIManager.UICurrentSiblineIndex++;

            this.transform.SetSiblingIndex(UIManager.UICurrentSiblineIndex);
            this.gameObject.SetActive(true);
        }
    }

    public virtual void Hide()
    {
        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 注册过事件请在此函数注销事件
    /// </summary>
    protected abstract void OnDestroy();

}
