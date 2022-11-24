using System;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An attribute that hides a field in the editor based on the state of
    /// another field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class ConditionalHideAttribute : ConditionalAttribute
    {
        /// <summary>
        /// Hides the field when the conditional field is true.
        /// </summary>
        /// <param name="conditionalField">The name of the conditional field.</param>
        public ConditionalHideAttribute(string conditionalField)
        {
            this.show = false;
            this.conditionalField = conditionalField;
            this.propertyDrawer = PropertyDrawer.Default;
        }

        /// <summary>
        /// Hides the field when the conditional field is set to the specified
        /// enum value (this assumes the conditional field is an enum).
        /// </summary>
        /// <param name="conditionalField">The name of the conditional field.</param>
        /// <param name="enumValue">The enum value to check for.</param>
        /// <param name="flags">Treats the enum as a bit field.</param>
        public ConditionalHideAttribute(string conditionalField, int enumValue, bool flags = false)
        {
            this.show = false;
            this.conditionalField = conditionalField;
            this.propertyDrawer = PropertyDrawer.Default;
            this.enumValue = enumValue;
            this.enumFlags = flags;
        }

        /// <summary>
        /// Hides the field when the conditional field is true.
        /// Draws the field as a slider.
        /// </summary>
        /// <param name="conditionalField">The name of the conditional field.</param>
        /// <param name="sliderMinValue">The minimum value of the slider.</param>
        /// <param name="sliderMaxValue">The maximum value of the slider.</param>
        public ConditionalHideAttribute(string conditionalField, float sliderMinValue, float sliderMaxValue)
        {
            this.show = false;
            this.conditionalField = conditionalField;
            this.propertyDrawer = PropertyDrawer.Slider;
            this.sliderMinValue = sliderMinValue;
            this.sliderMaxValue = sliderMaxValue;
        }

    }

}
