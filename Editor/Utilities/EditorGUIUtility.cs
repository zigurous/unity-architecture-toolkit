using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    internal static class EditorGUIUtility
    {
        public static float singleLineHeight => UnityEditor.EditorGUIUtility.singleLineHeight;
        public static float standardVerticalSpacing => UnityEditor.EditorGUIUtility.standardVerticalSpacing;
        public const float standardHorizontalSpacing = 4f;

        public static Rect GetFieldRect(Rect position, int columns)
        {
            float spacing = standardHorizontalSpacing * (columns - 1);
            position.width = (position.width - spacing) / columns;
            return position;
        }

        public static T FieldWrapper<T>(string label, System.Func<GUIContent, T> draw)
        {
            GUIContent content = new(label);

            float labelWidth = EditorStyles.label.CalcSize(content).x;
            float originalWidth = UnityEditor.EditorGUIUtility.labelWidth;

            UnityEditor.EditorGUIUtility.labelWidth = labelWidth;

            T value = draw(content);

            UnityEditor.EditorGUIUtility.labelWidth = originalWidth;

            return value;
        }

    }

}
