using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "TagManager", menuName = "Tag/Tag Manager")]
public class TagManager : ScriptableObject{

	public static readonly string PLAYER = "player";
    public static readonly string BULLET = "bullet";
    public static readonly string ENEMY = "enemy";
    public static readonly string WALL = "wall";
    public static readonly string END_ZONE = "end_zone";
    public static readonly string LEVEL_UP = "level_up";
    public static readonly string UPGRADE = "upgrade";

#if UNITY_EDITOR
    private void Awake()
    {
        InitTags();
    }
    
    [EasyButtons.Button]
    public void InitTags()
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");

        AddTags(ref tagsProp, new string[] { PLAYER, BULLET, ENEMY, END_ZONE, WALL, LEVEL_UP, UPGRADE });

        tagManager.ApplyModifiedProperties();
    }

    public void AddTags(ref SerializedProperty tagsProp, string[] tagName)
    {
        foreach (string tag in tagName) {
            AddTag(ref tagsProp, tag);
        }
    }

    public void AddTag(ref SerializedProperty tagsProp, string tag)
    {
        bool found = false;
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(tag)) { found = true; break; }
        }
        
        if (!found)
        {
            tagsProp.InsertArrayElementAtIndex(0);
            SerializedProperty n = tagsProp.GetArrayElementAtIndex(0);
            n.stringValue = tag;
        }
    }
#endif
}
