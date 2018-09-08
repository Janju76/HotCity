using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingFusionDictionary))]
public class BuildingFusionDictionaryEditor : ObjectDictionaryEditor<BuildingData, BuildingData> {

    protected override void DrawKeyValueHeader()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Adjacent Building");
        GUILayout.Space(buttonWidth);
        GUILayout.Label("Fusion Building");
        GUILayout.Space(buttonWidth);
        GUILayout.Space(buttonWidth);
        EditorGUILayout.EndHorizontal();
    }
}
