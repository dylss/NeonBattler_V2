

using Component;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HexagonGridCreatorComponent))]
public class HexagonGridEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        HexagonGridCreatorComponent hexagonGridCreator = (HexagonGridCreatorComponent)target;

        if(GUILayout.Button("Rebuild"))
        {
            hexagonGridCreator.Rebuild();
        }

        if(GUILayout.Button("Clear"))
        {
            hexagonGridCreator.Clear();
        }
    }
}