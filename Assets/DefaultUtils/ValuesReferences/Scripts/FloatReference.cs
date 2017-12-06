using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

[CreateAssetMenu(fileName ="floatReference", menuName = "Reference/Float")]
public class FloatReference : ValuesUpdater<float> {

}

#if UNITY_EDITOR
[CustomEditor(typeof(FloatReference))]
public class FloatReferenceInspector : Editor
{
    FloatReference refer;

    void OnEnable()
    {
        refer = (FloatReference)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Use constant");
        refer.isConstant = EditorGUILayout.Toggle(refer.isConstant);
        EditorGUILayout.EndHorizontal();
        if (refer.isConstant)
        {
            refer.m_constValue = EditorGUILayout.FloatField(refer.m_constValue);
        }
        else
        {
            refer.m_value = EditorGUILayout.FloatField(refer.m_value);
        }
        
    }
}
#endif