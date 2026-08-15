using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(InterfaceReference<,>))]
    public class InterfaceReferencePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            SerializedProperty target = property.FindPropertyRelative("m_Target");
            EditorGUI.ObjectField(position, target, GUIContent.none);

            EditorGUI.EndProperty();
        }

    }

}
