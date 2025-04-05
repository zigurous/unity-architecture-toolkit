using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Rect value, either a fixed value or <see cref="ScriptableRect"/>.
    /// </summary>
    [System.Serializable]
    public class RectReference : ValueReference<Rect, ScriptableRect>
    {
        /// <summary>
        /// Creates a new reference to a Rect with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public RectReference(Rect value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Rect stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public RectReference(ScriptableRect value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Rect.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Rect value.</returns>
        public static implicit operator Rect(RectReference reference) => reference.value;
    }

}
