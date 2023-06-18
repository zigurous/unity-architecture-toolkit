using UnityEngine;

namespace Zigurous.Architecture.Structs
{
    /// <summary>
    /// A range of values clamped between a lower and upper bound.
    /// </summary>
    [System.Serializable]
    public struct ClampedRange : INumberRange<float>
    {
        [SerializeField]
        [Tooltip("The min and max values of the range.")]
        private FloatRange range;

        /// <summary>
        /// The clamping values of the range.
        /// </summary>
        [Tooltip("The clamping values of the range.")]
        public FloatRange clamp;

        /// <inheritdoc/>
        public float min
        {
            get => range.min;
            set => range.min = clamp.Clamp(value);
        }

        /// <inheritdoc/>
        public float max
        {
            get => range.max;
            set => range.max = clamp.Clamp(value);
        }

        /// <inheritdoc/>
        public float delta => max - min;

        /// <inheritdoc/>
        public float median => (min + max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        /// <param name="clampLower">The lower clamping bound of the range.</param>
        /// <param name="clampUpper">The upper clamping bound of the range.</param>
        public ClampedRange(float min = 0f, float max = 1f, float clampLower = 0f, float clampUpper = 1f)
        {
            this.clamp = new FloatRange(clampLower, clampUpper);
            this.range = new FloatRange(clamp.Clamp(min), clamp.Clamp(max));
        }

        /// <inheritdoc/>
        public float Random()
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(float value)
        {
            return value >= min && value <= max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(float value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(min, max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public float Clamp(float value)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <inheritdoc/>
        public float Lerp(float t)
        {
            return Mathf.Lerp(min, max, t);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public float InverseLerp(float value)
        {
            return Mathf.InverseLerp(min, max, value);
        }

    }

}
