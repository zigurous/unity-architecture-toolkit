using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector2 value, either a constant or <see cref="Vector2Variable"/>.
    /// </summary>
    [System.Serializable]
    public class Vector2Reference : ValueReference<Vector2, Vector2Variable>
    {
        /// <summary>
        /// Creates a new Vector2 reference.
        /// </summary>
        public Vector2Reference() {}

        /// <summary>
        /// Creates a new Vector2 reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public Vector2Reference(Vector2 value) : base(value) {}

        /// <summary>
        /// Creates a new Vector2 reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public Vector2Reference(Vector2Variable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector2.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector2 value.</returns>
        public static implicit operator Vector2(Vector2Reference reference) => reference.value;
    }

}
