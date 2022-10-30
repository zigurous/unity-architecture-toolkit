using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Quaternion value, either a constant or <see cref="QuaternionVariable"/>.
    /// </summary>
    [System.Serializable]
    public class QuaternionReference : ValueReference<Quaternion, QuaternionVariable>
    {
        /// <summary>
        /// Creates a new Quaternion reference.
        /// </summary>
        public QuaternionReference() {}

        /// <summary>
        /// Creates a new Quaternion reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public QuaternionReference(Quaternion value) : base(value) {}

        /// <summary>
        /// Creates a new Quaternion reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public QuaternionReference(QuaternionVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Quaternion.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Quaternion value.</returns>
        public static implicit operator Quaternion(QuaternionReference reference) => reference.value;
    }

}
