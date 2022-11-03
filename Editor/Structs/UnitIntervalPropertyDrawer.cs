using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(UnitIntervalRange))]
    public class UnitIntervalRangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = Slider(position, property.FindPropertyRelative("m_Min"));
            position = Slider(position, property.FindPropertyRelative("m_Max"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect Slider(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 2);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            float value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.Slider(field, label, property.floatValue, 0f, 1f);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.floatValue = value;
            }

            return position;
        }

    }

}
