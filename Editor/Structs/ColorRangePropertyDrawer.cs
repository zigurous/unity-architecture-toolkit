using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(ColorRange))]
    public class ColorRangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = ColorField(position, property.FindPropertyRelative("m_Min"));
            position = ColorField(position, property.FindPropertyRelative("m_Max"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect ColorField(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 2);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            Color value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.ColorField(field, label, property.colorValue);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.colorValue = value;
            }

            return position;
        }

    }

}
