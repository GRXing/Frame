using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtend{

    public static Transform SearchChild(this Transform _transform, string _childName, int _findDepth = -1)
    {
        if (string.IsNullOrEmpty(_childName))
            return null;
        return DoSearchChild(_transform, _childName, _findDepth);
    }

    private static Transform DoSearchChild(Transform _transform, string _childName,int _findDepth)
    {
        Transform t_child = _transform.Find(_childName);
        if (t_child != null)
            return t_child;

        if (_findDepth != 0)
        {
            if (_findDepth > 0)
                _findDepth--;

            for (int i = 0; i < _transform.transform.childCount;i++ )
            {
                t_child = DoSearchChild(_transform.transform.GetChild(i),_childName,_findDepth);
                if (t_child != null)
                    return t_child;
            }
        }
        return null;
    }
}
