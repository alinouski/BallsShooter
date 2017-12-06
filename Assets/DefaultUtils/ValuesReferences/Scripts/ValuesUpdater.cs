using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class ValuesUpdater<T> : ScriptableObject {

    public T m_defaultValue;
    public T m_value;
    public T m_constValue;
    public bool isConstant = false;
    public bool clearOnStart = true;

    public T Value
    {
        get { return isConstant? m_constValue : m_value; }
        set { if (!isConstant) m_value = value; }
    }
}
