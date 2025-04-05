using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Quaternion value, either a fixed value or <see cref="ScriptableQuaternion"/>.
    /// </summary>
    [System.Serializable]
    public class QuaternionReference : ValueReference<Quaternion, ScriptableQuaternion>
    {
        /// <summary>
        /// Creates a new reference to a Quaternion with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public QuaternionReference(Quaternion value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Quaternion stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public QuaternionReference(ScriptableQuaternion value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Quaternion.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Quaternion value.</returns>
        public static implicit operator Quaternion(QuaternionReference reference) => reference.value;
    }

}
