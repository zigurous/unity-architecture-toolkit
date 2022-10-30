using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Rect value, either a constant or <see cref="RectVariable"/>.
    /// </summary>
    [System.Serializable]
    public class RectReference : ValueReference<Rect, RectVariable>
    {
        /// <summary>
        /// Creates a new Rect reference.
        /// </summary>
        public RectReference() {}

        /// <summary>
        /// Creates a new Rect reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public RectReference(Rect value) : base(value) {}

        /// <summary>
        /// Creates a new Rect reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public RectReference(RectVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Rect.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Rect value.</returns>
        public static implicit operator Rect(RectReference reference) => reference.value;
    }

}
