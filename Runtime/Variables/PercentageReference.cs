namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a percentage value, either a fixed value or <see cref="ScriptablePercentage"/>.
    /// </summary>
    [System.Serializable]
    public class PercentageReference : ValueReference<float, ScriptablePercentage>
    {
        /// <summary>
        /// Creates a new reference with a fixed percentage.
        /// </summary>
        /// <param name="percentage">The fixed percentage to use.</param>
        public PercentageReference(float percentage) : base(percentage) {}

        /// <summary>
        /// Creates a new reference to the percentage stored in a ScriptableObject.
        /// </summary>
        /// <param name="percentage">The ScriptableObject that stores the percentage.</param>
        public PercentageReference(ScriptablePercentage percentage) : base(percentage) {}

        /// <summary>
        /// Implicitly converts the reference to a percentage.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The percentage value.</returns>
        public static implicit operator float(PercentageReference reference) => reference.value;
    }

}
