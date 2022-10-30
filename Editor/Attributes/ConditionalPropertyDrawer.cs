using UnityEditor;
using UnityEngine;

namespace Zigurous.Architecture.Editor
{
    [CustomPropertyDrawer(typeof(ConditionalAttribute))]
    [CustomPropertyDrawer(typeof(ConditionalShowAttribute))]
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public sealed class ConditionalPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ConditionalAttribute conditionalAttribute = (ConditionalAttribute)attribute;
            bool enabled = GetConditionalAttributeResult(conditionalAttribute, property) == conditionalAttribute.show;

            if (enabled)
            {
                switch (conditionalAttribute.propertyDrawer)
                {
                    case ConditionalAttribute.PropertyDrawer.Slider:
                        EditorGUI.Slider(position, property, conditionalAttribute.sliderMinValue, conditionalAttribute.sliderMaxValue, label);
                        break;

                    case ConditionalAttribute.PropertyDrawer.Default:
                    default:
                        EditorGUI.PropertyField(position, property, label, true);
                        break;
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ConditionalAttribute conditionalAttribute = (ConditionalAttribute)attribute;
            bool enabled = GetConditionalAttributeResult(conditionalAttribute, property) == conditionalAttribute.show;

            if (enabled) {
                return EditorGUI.GetPropertyHeight(property, label);
            } else {
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }

        private bool GetConditionalAttributeResult(ConditionalAttribute attribute, SerializedProperty property)
        {
            SerializedProperty updatedProperty = null;

            if (true /*!property.isArray*/)
            {
                // Get the full relative property path of the attribute field so
                // we can have nested hiding
                string propertyPath = property.propertyPath;
                string conditionPath = propertyPath.Replace(property.name, attribute.conditionalField);
                updatedProperty = property.serializedObject.FindProperty(conditionPath);
            }

            // Fallback to the original implementation (does not work with
            // nested serializedObjects)
            if (updatedProperty == null) {
                updatedProperty = property.serializedObject.FindProperty(attribute.conditionalField);
            }

            // Verify the property type is supported
            if (updatedProperty != null) {
                return CheckPropertyType(attribute, updatedProperty);
            }

            return attribute.show;
        }

        private bool CheckPropertyType(ConditionalAttribute attribute, SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return property.boolValue;

                case SerializedPropertyType.Enum:
                    if (attribute.enumFlags) {
                        return (property.intValue & attribute.enumValue) == attribute.enumValue;
                    } else {
                        return property.enumValueIndex == attribute.enumValue;
                    }

                default:
                    Debug.LogError("The data type of the property used for conditional hiding [" + property.propertyType + "] is not currently supported.");
                    return attribute.show;
            }
        }

    }

}
