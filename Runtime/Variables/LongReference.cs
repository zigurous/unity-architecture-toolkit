namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a long value, either a fixed value or <see cref="ScriptableLong"/>.
    /// </summary>
    [System.Serializable]
    public class LongReference : ValueReference<long, ScriptableLong>
    {
        /// <summary>
        /// Creates a new reference to a long with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public LongReference(long value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the long stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public LongReference(ScriptableLong value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a long.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The long value.</returns>
        public static implicit operator long(LongReference reference) => reference.value;
    }

}
