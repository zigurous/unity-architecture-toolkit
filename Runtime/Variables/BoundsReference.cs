using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Bounds value, either a fixed value or <see cref="ScriptableBounds"/>.
    /// </summary>
    [System.Serializable]
    public class BoundsReference : ValueReference<Bounds, ScriptableBounds>
    {
        /// <summary>
        /// Creates a new reference to a Bounds with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public BoundsReference(Bounds value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Bounds stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public BoundsReference(ScriptableBounds value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Bounds.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Bounds value.</returns>
        public static implicit operator Bounds(BoundsReference reference) => reference.value;
    }

}
