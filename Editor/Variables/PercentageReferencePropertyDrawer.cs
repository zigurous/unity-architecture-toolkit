using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(PercentageReference), true)]
    public class PercentageReferencePropertyDrawer : PropertyDrawer
    {
        private readonly string[] popupOptions = { "Fixed Value", "Variable" };
        private static GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            SerializedProperty useVariable = property.FindPropertyRelative("useVariable");
            SerializedProperty variable = property.FindPropertyRelative("variable");
            SerializedProperty fixedValue = property.FindPropertyRelative("fixedValue");

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            Rect popupRect = new Rect(position);
            popupRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            popupRect.height = popupStyle.fixedHeight;
            popupRect.x += position.width - popupRect.width;
            popupRect.y += (EditorGUIUtility.singleLineHeight - popupStyle.fixedHeight) / 2f;
            position.width -= popupRect.width;

            EditorGUI.BeginChangeCheck();

            int result = EditorGUI.Popup(popupRect, useVariable.boolValue ? 1 : 0, popupOptions, popupStyle);
            useVariable.boolValue = result == 1;

            if (useVariable.boolValue) {
                EditorGUI.PropertyField(position, variable, GUIContent.none, true);
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
            SerializedProperty useVariable = property.FindPropertyRelative("useVariable");
            SerializedProperty variable = property.FindPropertyRelative("variable");
            SerializedProperty fixedValue = property.FindPropertyRelative("fixedValue");

            return EditorGUI.GetPropertyHeight(useVariable.boolValue ? variable : fixedValue, true);
        }

    }

}
