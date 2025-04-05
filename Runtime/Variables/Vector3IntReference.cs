using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector3Int value, either a fixed value or <see cref="ScriptableVector3Int"/>.
    /// </summary>
    [System.Serializable]
    public class Vector3IntReference : ValueReference<Vector3Int, ScriptableVector3Int>
    {
        /// <summary>
        /// Creates a new reference to a Vector3Int with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public Vector3IntReference(Vector3Int value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Vector3Int stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public Vector3IntReference(ScriptableVector3Int value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector3Int.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector3Int value.</returns>
        public static implicit operator Vector3Int(Vector3IntReference reference) => reference.value;
    }

}
