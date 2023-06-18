namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a long value, either a constant or <see cref="LongVariable"/>.
    /// </summary>
    [System.Serializable]
    public class LongReference : ValueReference<long, LongVariable>
    {
        /// <summary>
        /// Creates a new long reference.
        /// </summary>
        public LongReference() {}

        /// <summary>
        /// Creates a new long reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public LongReference(long value) : base(value) {}

        /// <summary>
        /// Creates a new long reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public LongReference(LongVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a long.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The long value.</returns>
        public static implicit operator long(LongReference reference) => reference.value;
    }

}
