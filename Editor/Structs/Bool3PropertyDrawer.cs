using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(Bool3))]
    public class Bool3PropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = BoolField(position, property.FindPropertyRelative("x"));
            position = BoolField(position, property.FindPropertyRelative("y"));
            position = BoolField(position, property.FindPropertyRelative("z"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect BoolField(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 3);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            bool value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.Toggle(field, label, property.boolValue);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.boolValue = value;
            }

            return position;
        }

    }

}
