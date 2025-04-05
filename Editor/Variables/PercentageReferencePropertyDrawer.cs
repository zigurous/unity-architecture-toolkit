using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(PercentageReference), true)]
    public class PercentageReferencePropertyDrawer : PropertyDrawer
    {
        private readonly string[] popupOptions = { "Fixed Value", "Scriptable Value" };
        private static GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions")) {
                imagePosition = ImagePosition.ImageOnly
            };

            SerializedProperty useScriptableValue = property.FindPropertyRelative("useScriptableValue");
            SerializedProperty scriptableValue = property.FindPropertyRelative("scriptableValue");
            SerializedProperty fixedValue = property.FindPropertyRelative("fixedValue");

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            Rect popupRect = new(position)
            {
                width = popupStyle.fixedWidth + popupStyle.margin.right,
                height = popupStyle.fixedHeight
            };
            popupRect.x += position.width - popupRect.width;
            popupRect.y += (EditorGUIUtility.singleLineHeight - popupStyle.fixedHeight) / 2f;
            position.width -= popupRect.width;

            EditorGUI.BeginChangeCheck();

            int result = EditorGUI.Popup(popupRect, useScriptableValue.boolValue ? 1 : 0, popupOptions, popupStyle);
            useScriptableValue.boolValue = result == 1;

            if (useScriptableValue.boolValue) {
                EditorGUI.PropertyField(position, scriptableValue, GUIContent.none, true);
            } else {
                fixedValue.floatValue = EditorGUI.Slider(position, fixedValue.floatValue, 0f, 1f);
            }

            if (EditorGUI.EndChangeCheck()) {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty useScriptableValue = property.FindPropertyRelative("useScriptableValue");

            if (useScriptableValue.boolValue)
            {
                SerializedProperty scriptableValue = property.FindPropertyRelative("scriptableValue");
                return EditorGUI.GetPropertyHeight(scriptableValue, true);
            }
            else
            {
                SerializedProperty fixedValue = property.FindPropertyRelative("fixedValue");
                return EditorGUI.GetPropertyHeight(fixedValue, true);
            }
        }

    }

}
