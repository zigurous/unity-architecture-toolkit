namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a float value, either a fixed value or <see cref="ScriptableFloat"/>.
    /// </summary>
    [System.Serializable]
    public class FloatReference : ValueReference<float, ScriptableFloat>
    {
        /// <summary>
        /// Creates a new reference to a float with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public FloatReference(float value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the float stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public FloatReference(ScriptableFloat value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a float.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The float value.</returns>
        public static implicit operator float(FloatReference reference) => reference.value;
    }

}
