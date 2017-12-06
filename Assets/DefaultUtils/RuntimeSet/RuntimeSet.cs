using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

//[CreateAssetMenu(fileName = "val", menuName = "value", order = 51)]
[System.Serializable]
public class RuntimeSet<T> : ScriptableObject
{
    public List<T> values = new List<T>();

    public void Add(T item)
    {
        values.Add(item);
    }

    public void Remove(T item)
    {
        if (values.Contains(item)) values.Remove(item);
    }
}
