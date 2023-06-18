using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(DoubleRange))]
    public class DoubleRangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = DoubleField(position, property.FindPropertyRelative("m_Min"));
            position = DoubleField(position, property.FindPropertyRelative("m_Max"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect DoubleField(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 2);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            double value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.DoubleField(field, label, property.doubleValue);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.doubleValue = value;
            }

            return position;
        }

    }

}
