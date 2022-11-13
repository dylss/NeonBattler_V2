using UnityEditor;
using UnityEngine;

namespace Editor
{
    
    [CustomEditor(typeof(BattleObjectBuilderController))]
    public class BattleObjectBuilderControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            BattleObjectBuilderController battleObjectBuilderController = (BattleObjectBuilderController) target;

            if (GUILayout.Button("Update selection (Press 2x)"))
            {
                battleObjectBuilderController.UpdateSelection();
            }

            if (GUILayout.Button("Clear all"))
            {
                battleObjectBuilderController.ClearAll();
            }
            
            if (GUILayout.Button("Build"))
            {
                battleObjectBuilderController.Build();
            }
        }
    }
}