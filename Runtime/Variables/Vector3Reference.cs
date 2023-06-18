using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector3 value, either a constant or <see cref="Vector3Variable"/>.
    /// </summary>
    [System.Serializable]
    public class Vector3Reference : ValueReference<Vector3, Vector3Variable>
    {
        /// <summary>
        /// Creates a new Vector3 reference.
        /// </summary>
        public Vector3Reference() {}

        /// <summary>
        /// Creates a new Vector3 reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public Vector3Reference(Vector3 value) : base(value) {}

        /// <summary>
        /// Creates a new Vector3 reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public Vector3Reference(Vector3Variable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector3.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector3 value.</returns>
        public static implicit operator Vector3(Vector3Reference reference) => reference.value;
    }

}
