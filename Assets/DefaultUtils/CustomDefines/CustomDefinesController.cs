using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
[CreateAssetMenu(fileName ="DefinesSettings", menuName ="CustomSettings/definesSettings")]
public class CustomDefinesSettings : ScriptableObject {

    [Header("Settings")]
    public CustomDefinePlatformSettings[] settings;

    [EasyButtons.Button]
    public void Init()
    {
        foreach (CustomDefinePlatformSettings p in settings)
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(p.deviceTarget, p.ResultDefines());
            Debug.Log(p.deviceTarget.ToString()+"  "+PlayerSettings.GetScriptingDefineSymbolsForGroup(p.deviceTarget));
        }
    }
}

[CreateAssetMenu(fileName = "DefinesPlatformSettings", menuName = "CustomSettings/definesPlatform")]
public class CustomDefinePlatformSettings: ScriptableObject
{    
    public BuildTargetGroup deviceTarget;

    public string[] defines;
    
    public string ResultDefines()
    {
        string str = "";
        foreach (string s in defines)
        {
            str += s + ";";
        }
        return str;
    }
}

[CustomEditor(typeof(CustomDefinePlatformSettings))]
public class CustomDefinePInspector : Editor
{
    private string helpMessage;



    private void OnEnable()
    {
        CreateHelpBox();
    }

    private void CreateHelpBox()
    {
        string path = "Assets/DefaultUtils/CustomDefinesInfo.txt";
        
        StreamReader reader = new StreamReader(path);
        helpMessage = reader.ReadToEnd();
        reader.Close();
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox(helpMessage, MessageType.Info);
        DrawDefaultInspector();
    }
}
#endif