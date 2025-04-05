using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector2Int value, either a fixed value or <see cref="ScriptableVector2Int"/>.
    /// </summary>
    [System.Serializable]
    public class Vector2IntReference : ValueReference<Vector2Int, ScriptableVector2Int>
    {
        /// <summary>
        /// Creates a new reference to a Vector2Int with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public Vector2IntReference(Vector2Int value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Vector2Int stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public Vector2IntReference(ScriptableVector2Int value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector2Int.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector2Int value.</returns>
        public static implicit operator Vector2Int(Vector2IntReference reference) => reference.value;
    }

}
