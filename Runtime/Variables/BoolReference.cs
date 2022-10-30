namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a boolean value, either a constant or <see cref="BoolVariable"/>.
    /// </summary>
    [System.Serializable]
    public class BoolReference : ValueReference<bool, BoolVariable>
    {
        /// <summary>
        /// Creates a new boolean reference.
        /// </summary>
        public BoolReference() {}

        /// <summary>
        /// Creates a new boolean reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public BoolReference(bool value) : base(value) {}

        /// <summary>
        /// Creates a new boolean reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public BoolReference(BoolVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a boolean.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The boolean value.</returns>
        public static implicit operator bool(BoolReference reference) => reference.value;
    }

}
