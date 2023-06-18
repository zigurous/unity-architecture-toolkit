namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a percentage value, either a constant or <see cref="PercentageVariable"/>.
    /// </summary>
    [System.Serializable]
    public class PercentageReference : ValueReference<float, PercentageVariable>
    {
        /// <summary>
        /// Creates a new percentage reference.
        /// </summary>
        public PercentageReference() {}

        /// <summary>
        /// Creates a new percentage reference with the fixed value.
        /// </summary>
        /// <param name="value">The fixed value to set.</param>
        public PercentageReference(float value) : base(value) {}

        /// <summary>
        /// Creates a new percentage reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public PercentageReference(PercentageVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a float.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The float value.</returns>
        public static implicit operator float(PercentageReference reference) => reference.value;
    }

}
