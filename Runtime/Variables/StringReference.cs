namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a string value, either a constant or <see cref="StringVariable"/>.
    /// </summary>
    [System.Serializable]
    public class StringReference : ValueReference<string, StringVariable>
    {
        /// <summary>
        /// Creates a new string reference.
        /// </summary>
        public StringReference() {}

        /// <summary>
        /// Creates a new string reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public StringReference(string value) : base(value) {}

        /// <summary>
        /// Creates a new string reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public StringReference(StringVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a string.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The string value.</returns>
        public static implicit operator string(StringReference reference) => reference.value;
    }

}
