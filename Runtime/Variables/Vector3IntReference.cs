using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector3Int value, either a constant or <see cref="Vector3IntVariable"/>.
    /// </summary>
    [System.Serializable]
    public class Vector3IntReference : ValueReference<Vector3Int, Vector3IntVariable>
    {
        /// <summary>
        /// Creates a new Vector3Int reference.
        /// </summary>
        public Vector3IntReference() {}

        /// <summary>
        /// Creates a new Vector3Int reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public Vector3IntReference(Vector3Int value) : base(value) {}

        /// <summary>
        /// Creates a new Vector3Int reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public Vector3IntReference(Vector3IntVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector3Int.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector3Int value.</returns>
        public static implicit operator Vector3Int(Vector3IntReference reference) => reference.value;
    }

}
