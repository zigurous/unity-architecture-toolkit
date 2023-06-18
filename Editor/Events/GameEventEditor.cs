using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomEditor(typeof(GameEvent), true)]
    public class GameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;

            if (GUILayout.Button("Raise")) {
                e.Raise();
            }
        }

    }

}
