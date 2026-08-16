using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(UIntRange))]
    public class UIntRangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            position = UIntField(position, property.FindPropertyRelative("m_Min"));
            position = UIntField(position, property.FindPropertyRelative("m_Max"));

            EditorGUI.EndProperty();
        }

        private Rect UIntField(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 2);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            int value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.IntField(field, label, property.intValue);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.intValue = value;
            }

            return position;
        }

    }

}
