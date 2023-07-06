using Tolian.Runtime.Core.Managers;
using Tolian.Runtime.Core.Managers.LevelSystem;
using UnityEditor;
using UnityEngine;

namespace Tolian.Editor.ManagerLevelSystem
{
    /// <summary>
    /// Gives more functionality to ManagerLevel class
    /// </summary>
    [CustomEditor(typeof(ManagerLevel))]
    public class ManagerLevelEditor : UnityEditor.Editor
    {
        /// <summary>
        /// This override lets users to refresh "build scenes" automatically according to ManagerLevel 
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ManagerLevel managerLevel = (ManagerLevel) target;
            EditorGUILayout.LabelField("Custom Actions For ManagerLevel", EditorStyles.boldLabel);
            if (GUILayout.Button( "Add Scenes In Build To ManagerLevel's Level List"))
            {
                var scenes = EditorBuildSettings.scenes;
                managerLevel.Levels.Clear();
            
                for (int i = 0; i < scenes.Length; i++)
                {
                    var scene = scenes[i];
                    if (scene.enabled)
                    {
                        if (i == 0)
                        {
                            managerLevel.Levels.Add(new Level(i,false));
                        }
                        else
                        {
                            managerLevel.Levels.Add(new Level(i,true));
                        }
                  
                    }
                }
            }
        }
    }
}

