using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector3 value, either a fixed value or <see cref="ScriptableVector3"/>.
    /// </summary>
    [System.Serializable]
    public class Vector3Reference : ValueReference<Vector3, ScriptableVector3>
    {
        /// <summary>
        /// Creates a new reference to a Vector3 with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public Vector3Reference(Vector3 value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Vector3 stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public Vector3Reference(ScriptableVector3 value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector3.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector3 value.</returns>
        public static implicit operator Vector3(Vector3Reference reference) => reference.value;
    }

}
