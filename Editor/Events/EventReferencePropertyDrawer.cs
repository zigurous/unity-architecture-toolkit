using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(EventReference), true)]
    public sealed class EventReferencePropertyDrawer : PropertyDrawer
    {
        private readonly string[] popupOptions = { "Use Unity Event", "Use Game Event" };
        private static GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            SerializedProperty useUnityEvent = property.FindPropertyRelative("useUnityEvent");
            SerializedProperty unityEvent = property.FindPropertyRelative("unityEvent");
            SerializedProperty gameEvent = property.FindPropertyRelative("gameEvent");

            label = EditorGUI.BeginProperty(position, label, property);

            if (!useUnityEvent.boolValue) {
                position = EditorGUI.PrefixLabel(position, label);
            }

            Rect popupRect = new Rect(position);
            popupRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            popupRect.height = EditorGUIUtility.singleLineHeight;
            popupRect.y += (popupRect.height - popupStyle.fixedHeight) / 2f;
            position.width -= popupRect.width;
            popupRect.x += position.width;

            EditorGUI.BeginChangeCheck();

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(popupRect, useUnityEvent.boolValue ? 0 : 1, popupOptions, popupStyle);
            useUnityEvent.boolValue = result == 0;

            if (useUnityEvent.boolValue) {
                EditorGUI.PropertyField(position, unityEvent, label, true);
            } else {
                EditorGUI.PropertyField(position, gameEvent, GUIContent.none, true);
            }

            if (EditorGUI.EndChangeCheck()) {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty useUnityEvent = property.FindPropertyRelative("useUnityEvent");
            SerializedProperty unityEvent = property.FindPropertyRelative("unityEvent");
            SerializedProperty gameEvent = property.FindPropertyRelative("gameEvent");

            return EditorGUI.GetPropertyHeight(useUnityEvent.boolValue ? unityEvent : gameEvent, true);
        }

    }

}
