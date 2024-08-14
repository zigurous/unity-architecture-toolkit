namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a duration, either a fixed value or <see cref="DurationVariable"/>.
    /// </summary>
    [System.Serializable]
    public class DurationReference : ValueReference<float, DurationVariable>
    {
        /// <summary>
        /// Creates a new duration reference.
        /// </summary>
        public DurationReference() {}

        /// <summary>
        /// Creates a new duration reference with a fixed duration.
        /// </summary>
        /// <param name="duration">The fixed duration to set.</param>
        public DurationReference(float duration) : base(duration) {}

        /// <summary>
        /// Creates a new duration reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public DurationReference(DurationVariable variable) : base(variable) {}

        /// <summary>
        /// Implicitly converts the reference to a duration.
        /// </summary>
        /// <param name="reference">The reference to convert.</param>
        /// <returns>The duration value.</returns>
        public static implicit operator float(DurationReference reference) => reference.value;
    }

}
