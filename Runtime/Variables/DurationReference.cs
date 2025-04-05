namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a duration value, either a fixed value or <see cref="ScriptableDuration"/>.
    /// </summary>
    [System.Serializable]
    public class DurationReference : ValueReference<float, ScriptableDuration>
    {
        /// <summary>
        /// Creates a new reference with a fixed duration.
        /// </summary>
        /// <param name="duration">The fixed duration to use.</param>
        public DurationReference(float duration) : base(duration) {}

        /// <summary>
        /// Creates a new reference to the duration stored in a ScriptableObject.
        /// </summary>
        /// <param name="duration">The ScriptableObject that stores the duration.</param>
        public DurationReference(ScriptableDuration duration) : base(duration) {}

        /// <summary>
        /// Implicitly converts the reference to a duration.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The duration value.</returns>
        public static implicit operator float(DurationReference reference) => reference.value;
    }

}
