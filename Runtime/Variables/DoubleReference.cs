namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a double value, either a constant or <see cref="DoubleVariable"/>.
    /// </summary>
    [System.Serializable]
    public class DoubleReference : ValueReference<double, DoubleVariable>
    {
        /// <summary>
        /// Creates a new double reference.
        /// </summary>
        public DoubleReference() {}

        /// <summary>
        /// Creates a new double reference with the fixed value.
        /// </summary>
        /// <param name="value">The fixed value to set.</param>
        public DoubleReference(double value) : base(value) {}

        /// <summary>
        /// Creates a new double reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public DoubleReference(DoubleVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a double.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The double value.</returns>
        public static implicit operator double(DoubleReference reference) => reference.value;
    }

}
