#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExportProjectController : MonoBehaviour {

    [MenuItem("MyUtils/ExportAll")]
    public static void Export()
    {
        string[] projectContent = AssetDatabase.GetAllAssetPaths();
        AssetDatabase.ExportPackage(projectContent, "UltimateTemplate.unitypackage", ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets);
        Debug.Log("Project Exported");
    }
}
#endif