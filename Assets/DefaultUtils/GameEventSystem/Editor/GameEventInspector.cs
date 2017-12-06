using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(GameEvent))]
public class GameEventInspector : Editor
{
    GameEvent ge;

    void OnEnable()
    {
        ge = (GameEvent)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Execute"))
        {
            ge.Raise();
            Debug.Log("Editor event click");
        }
    }
}