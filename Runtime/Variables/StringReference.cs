namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a string value, either a fixed value or <see cref="ScriptableString"/>.
    /// </summary>
    [System.Serializable]
    public class StringReference : ValueReference<string, ScriptableString>
    {
        /// <summary>
        /// Creates a new reference to a string with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public StringReference(string value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the string stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public StringReference(ScriptableString value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a string.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The string value.</returns>
        public static implicit operator string(StringReference reference) => reference.value;
    }

}
