namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a short value, either a fixed value or <see cref="ScriptableShort"/>.
    /// </summary>
    [System.Serializable]
    public class ShortReference : ValueReference<short, ScriptableShort>
    {
        /// <summary>
        /// Creates a new reference to a short with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public ShortReference(short value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the short stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public ShortReference(ScriptableShort value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a short.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The short value.</returns>
        public static implicit operator short(ShortReference reference) => reference.value;
    }

}
