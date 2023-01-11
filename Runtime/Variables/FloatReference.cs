namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a float value, either a constant or <see cref="FloatVariable"/>.
    /// </summary>
    [System.Serializable]
    public class FloatReference : ValueReference<float, FloatVariable>
    {
        /// <summary>
        /// Creates a new float reference.
        /// </summary>
        public FloatReference() {}

        /// <summary>
        /// Creates a new float reference with the fixed value.
        /// </summary>
        /// <param name="value">The fixed value to set.</param>
        public FloatReference(float value) : base(value) {}

        /// <summary>
        /// Creates a new float reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public FloatReference(FloatVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a float.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The float value.</returns>
        public static implicit operator float(FloatReference reference) => reference.value;
    }

}
