using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

[CreateAssetMenu(fileName = "intReference", menuName = "Reference/Int")]
public class IntReference : ValuesUpdater<int>
{
    private void OnEnable()
    {
        if (clearOnStart)
        {
            m_value = m_defaultValue;
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(IntReference))]
public class IntReferenceInspector : Editor
{
    IntReference refer;

    void OnEnable()
    {
        refer = (IntReference)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Use constant");
        refer.isConstant = EditorGUILayout.Toggle(refer.isConstant);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("ClearOnStart");
        refer.clearOnStart = EditorGUILayout.Toggle(refer.clearOnStart);
        EditorGUILayout.EndHorizontal();
        if (refer.isConstant)
        {
            refer.m_constValue = EditorGUILayout.IntField(refer.m_constValue);
        }
        else
        {
            refer.m_value = EditorGUILayout.IntField(refer.m_value);
        }
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("defaultValue");        
        EditorGUILayout.EndHorizontal();
        refer.m_defaultValue = EditorGUILayout.IntField(refer.m_defaultValue);
    }
}
#endif