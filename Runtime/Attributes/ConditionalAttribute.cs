using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An attribute that shows or hides a field in the editor based on a condition.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public abstract class ConditionalAttribute : PropertyAttribute
    {
        /// <summary>
        /// A type of property drawer used to draw the field.
        /// </summary>
        public enum PropertyDrawer
        {
            /// <summary>
            /// Draws the field as a normal property based on its type.
            /// </summary>
            Default,

            /// <summary>
            /// Draws the field with a slider.
            /// </summary>
            Slider,
        }

        /// <summary>
        /// The type of property drawer to use to draw the field.
        /// </summary>
        public PropertyDrawer propertyDrawer;

        /// <summary>
        /// The field being used to determine if the condition is met.
        /// </summary>
        public string conditionalField;

        /// <summary>
        /// Whether to show or hide the field when the condition is met.
        /// </summary>
        public bool show;

        /// <summary>
        /// The enum value to use to determine if the condition is met (only
        /// applicable if the conditional field is an enum).
        /// </summary>
        public int enumValue;

        /// <summary>
        /// Whether the enum should be treated as a bit field (only applicable
        /// if the conditional field is an enum).
        /// </summary>
        public bool enumFlags;

        /// <summary>
        /// The minimum value of the slider (only applicable for Slider property
        /// drawers).
        /// </summary>
        public float sliderMinValue;

        /// <summary>
        /// The maximum value of the slider (only applicable for Slider property
        /// drawers).
        /// </summary>
        public float sliderMaxValue;

    }

}
