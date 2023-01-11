namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a uint value, either a constant or <see cref="UIntVariable"/>.
    /// </summary>
    [System.Serializable]
    public class UIntReference : ValueReference<uint, UIntVariable>
    {
        /// <summary>
        /// Creates a new uint reference.
        /// </summary>
        public UIntReference() {}

        /// <summary>
        /// Creates a new uint reference with the fixed value.
        /// </summary>
        /// <param name="value">The fixed value to set.</param>
        public UIntReference(uint value) : base(value) {}

        /// <summary>
        /// Creates a new uint reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public UIntReference(UIntVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a uint.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The uint value.</returns>
        public static implicit operator uint(UIntReference reference) => reference.value;
    }

}
