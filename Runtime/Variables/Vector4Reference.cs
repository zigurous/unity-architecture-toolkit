using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector4 value, either a constant or <see cref="Vector4Variable"/>.
    /// </summary>
    [System.Serializable]
    public class Vector4Reference : ValueReference<Vector4, Vector4Variable>
    {
        /// <summary>
        /// Creates a new Vector4 reference.
        /// </summary>
        public Vector4Reference() {}

        /// <summary>
        /// Creates a new Vector4 reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public Vector4Reference(Vector4 value) : base(value) {}

        /// <summary>
        /// Creates a new Vector4 reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public Vector4Reference(Vector4Variable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector4.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector4 value.</returns>
        public static implicit operator Vector4(Vector4Reference reference) => reference.value;
    }

}
