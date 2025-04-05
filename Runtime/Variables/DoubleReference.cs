namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a double value, either a fixed value or <see cref="ScriptableDouble"/>.
    /// </summary>
    [System.Serializable]
    public class DoubleReference : ValueReference<double, ScriptableDouble>
    {
        /// <summary>
        /// Creates a new reference to a double with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public DoubleReference(double value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the double stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public DoubleReference(ScriptableDouble value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a double.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The double value.</returns>
        public static implicit operator double(DoubleReference reference) => reference.value;
    }

}
