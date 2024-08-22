using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(IndentAttribute), true)]
    public class IndentPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var indentAttribute = (IndentAttribute)attribute;

            // using (new EditorGUI.IndentLevelScope(indentAttribute.indentLevel))
            // {
            //     EditorGUI.PropertyField(position, property, label, true);
            // }

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = indent + indentAttribute.indentLevel;
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.indentLevel = indent;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

    }

}
