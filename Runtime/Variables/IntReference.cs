namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to an int value, either a fixed value or <see cref="ScriptableInt"/>.
    /// </summary>
    [System.Serializable]
    public class IntReference : ValueReference<int, ScriptableInt>
    {
        /// <summary>
        /// Creates a new reference to an int with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public IntReference(int value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the int stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public IntReference(ScriptableInt value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to an int.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The int value.</returns>
        public static implicit operator int(IntReference reference) => reference.value;
    }

}
