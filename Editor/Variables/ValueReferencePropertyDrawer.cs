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
        private readonly string[] popupOptions = { "Use Constant", "Use Variable" };
        private static GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("constantValue");
            SerializedProperty variable = property.FindPropertyRelative("variable");

            Rect buttonRect = new Rect(position);
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            buttonRect.height = EditorGUIUtility.singleLineHeight;
            buttonRect.y += (buttonRect.height - popupStyle.fixedHeight) / 2f;
            position.width -= buttonRect.width;
            buttonRect.x += position.width;

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, popupStyle);
            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(position, useConstant.boolValue ? constantValue : variable, GUIContent.none, true);

            if (EditorGUI.EndChangeCheck()) {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("constantValue");

            if (useConstant.boolValue) {
                return EditorGUI.GetPropertyHeight(constantValue, true);
            } else {
                return base.GetPropertyHeight(property, label);
            }
        }

    }

}
