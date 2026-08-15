using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomEditor(typeof(ScriptableGameEvent), true)]
    public class ScriptableGameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            ScriptableGameEvent e = target as ScriptableGameEvent;

            if (GUILayout.Button("Raise")) {
                e.Raise();
            }
        }

    }

}
