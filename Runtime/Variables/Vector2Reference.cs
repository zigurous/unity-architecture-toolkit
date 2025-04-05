using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a Vector2 value, either a fixed value or <see cref="ScriptableVector2"/>.
    /// </summary>
    [System.Serializable]
    public class Vector2Reference : ValueReference<Vector2, ScriptableVector2>
    {
        /// <summary>
        /// Creates a new reference to a Vector2 with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public Vector2Reference(Vector2 value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the Vector2 stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public Vector2Reference(ScriptableVector2 value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a Vector2.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The Vector2 value.</returns>
        public static implicit operator Vector2(Vector2Reference reference) => reference.value;
    }

}
