namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a uint value, either a fixed value or <see cref="ScriptableUInt"/>.
    /// </summary>
    [System.Serializable]
    public class UIntReference : ValueReference<uint, ScriptableUInt>
    {
        /// <summary>
        /// Creates a new reference to a uint with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public UIntReference(uint value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the uint stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public UIntReference(ScriptableUInt value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a uint.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The uint value.</returns>
        public static implicit operator uint(UIntReference reference) => reference.value;
    }

}
