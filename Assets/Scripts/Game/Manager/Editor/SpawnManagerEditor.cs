using Manager;
using UnityEditor;
using UnityEngine;

namespace Game.Manager.Editor
{
    [CustomEditor(typeof(SpawnManager))]
    public class SpawnManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            SpawnManager spawnManager = target as SpawnManager;
            if (GUILayout.Button("Manually spawn BattleObjects"))
            {
                spawnManager.ManuallySpawnBattleObjects();
            }
        }
    }
}