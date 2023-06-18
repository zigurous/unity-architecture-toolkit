using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Bounds value, either a constant or <see cref="BoundsVariable"/>.
    /// </summary>
    [System.Serializable]
    public class BoundsReference : ValueReference<Bounds, BoundsVariable>
    {
        /// <summary>
        /// Creates a new Bounds reference.
        /// </summary>
        public BoundsReference() {}

        /// <summary>
        /// Creates a new Bounds reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public BoundsReference(Bounds value) : base(value) {}

        /// <summary>
        /// Creates a new Bounds reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public BoundsReference(BoundsVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Bounds.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Bounds value.</returns>
        public static implicit operator Bounds(BoundsReference reference) => reference.value;
    }

}
