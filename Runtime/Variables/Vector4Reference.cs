using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector4 value, either a fixed value or <see cref="ScriptableVector4"/>.
    /// </summary>
    [System.Serializable]
    public class Vector4Reference : ValueReference<Vector4, ScriptableVector4>
    {
        /// <summary>
        /// Creates a new reference to a Vector4 with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public Vector4Reference(Vector4 value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Vector4 stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public Vector4Reference(ScriptableVector4 value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector4.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector4 value.</returns>
        public static implicit operator Vector4(Vector4Reference reference) => reference.value;
    }

}
