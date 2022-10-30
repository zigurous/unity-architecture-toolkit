using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(RenameAttribute))]
    public class RenamePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, new GUIContent((attribute as RenameAttribute).newName));
        }

    }

}
