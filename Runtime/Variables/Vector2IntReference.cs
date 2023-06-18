using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector2Int value, either a constant or <see cref="Vector2IntVariable"/>.
    /// </summary>
    [System.Serializable]
    public class Vector2IntReference : ValueReference<Vector2Int, Vector2IntVariable>
    {
        /// <summary>
        /// Creates a new Vector2Int reference.
        /// </summary>
        public Vector2IntReference() {}

        /// <summary>
        /// Creates a new Vector2Int reference with the fixed value.
        /// </summary>
        /// <param name="value">The fixed value to set.</param>
        public Vector2IntReference(Vector2Int value) : base(value) {}

        /// <summary>
        /// Creates a new Vector2Int reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public Vector2IntReference(Vector2IntVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector2Int.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector2Int value.</returns>
        public static implicit operator Vector2Int(Vector2IntReference reference) => reference.value;
    }

}
