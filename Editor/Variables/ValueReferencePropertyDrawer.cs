using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(BoolReference), true)]
    [CustomPropertyDrawer(typeof(BoundsReference), true)]
    [CustomPropertyDrawer(typeof(DoubleReference), true)]
    [CustomPropertyDrawer(typeof(FloatReference), true)]
    [CustomPropertyDrawer(typeof(IntReference), true)]
    [CustomPropertyDrawer(typeof(LongReference), true)]
    [CustomPropertyDrawer(typeof(QuaternionReference), true)]
    [CustomPropertyDrawer(typeof(RectReference), true)]
    [CustomPropertyDrawer(typeof(ShortReference), true)]
    [CustomPropertyDrawer(typeof(StringReference), true)]
    [CustomPropertyDrawer(typeof(UIntReference), true)]
    [CustomPropertyDrawer(typeof(Vector2Reference), true)]
    [CustomPropertyDrawer(typeof(Vector2IntReference), true)]
    [CustomPropertyDrawer(typeof(Vector3Reference), true)]
    [CustomPropertyDrawer(typeof(Vector3IntReference), true)]
    [CustomPropertyDrawer(typeof(Vector4Reference), true)]
    public class ValueReferencePropertyDrawer : PropertyDrawer
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

            EditorGUI.PropertyField(position, useVariable.boolValue ? variable : fixedValue, GUIContent.none, true);

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
