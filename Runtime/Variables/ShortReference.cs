namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a short value, either a constant or <see cref="ShortVariable"/>.
    /// </summary>
    [System.Serializable]
    public class ShortReference : ValueReference<short, ShortVariable>
    {
        /// <summary>
        /// Creates a new short reference.
        /// </summary>
        public ShortReference() {}

        /// <summary>
        /// Creates a new short reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public ShortReference(short value) : base(value) {}

        /// <summary>
        /// Creates a new short reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public ShortReference(ShortVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a short.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The short value.</returns>
        public static implicit operator short(ShortReference reference) => reference.value;
    }

}
