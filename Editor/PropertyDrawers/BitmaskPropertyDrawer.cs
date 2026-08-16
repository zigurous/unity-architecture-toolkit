using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(Bitmask))]
    public class BitmaskPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            EditorGUI.BeginChangeCheck();

            SerializedProperty mask = property.FindPropertyRelative("mask");
            int value = EditorGUI.IntField(position, mask.intValue);

            if (EditorGUI.EndChangeCheck()) {
                mask.intValue = value;
            }

            EditorGUI.EndProperty();
        }

    }

}
