namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to an int value, either a constant or <see cref="IntVariable"/>.
    /// </summary>
    [System.Serializable]
    public class IntReference : ValueReference<int, IntVariable>
    {
        /// <summary>
        /// Creates a new int reference.
        /// </summary>
        public IntReference() {}

        /// <summary>
        /// Creates a new int reference with the fixed value.
        /// </summary>
        /// <param name="value">The fixed value to set.</param>
        public IntReference(int value) : base(value) {}

        /// <summary>
        /// Creates a new int reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public IntReference(IntVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to an int.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The int value.</returns>
        public static implicit operator int(IntReference reference) => reference.value;
    }

}
