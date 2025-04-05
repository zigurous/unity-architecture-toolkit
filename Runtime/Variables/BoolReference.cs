namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a bool value, either a fixed value or <see cref="ScriptableBool"/>.
    /// </summary>
    [System.Serializable]
    public class BoolReference : ValueReference<bool, ScriptableBool>
    {
        /// <summary>
        /// Creates a new reference to a bool with a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public BoolReference(bool value) : base(value) {}

        /// <summary>
        /// Creates a new reference to the bool stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public BoolReference(ScriptableBool value) : base(value) {}

        /// <summary>
        /// Implicitly converts the reference to a bool.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The bool value.</returns>
        public static implicit operator bool(BoolReference reference) => reference.value;
    }

}
