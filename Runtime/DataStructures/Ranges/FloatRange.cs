using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of float values.
    /// </summary>
    [System.Serializable]
    public struct FloatRange : INumberRange<float>
    {
        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, 0f)</c>.
        /// </summary>
        public static FloatRange zero => new(0f, 0f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(1f, 1f)</c>.
        /// </summary>
        public static FloatRange one => new(1f, 1f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, 1f)</c>.
        /// </summary>
        public static FloatRange percent => new(0f, 1f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, float.MaxValue)</c>.
        /// </summary>
        public static FloatRange positive => new(0f, float.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(float.MinValue, 0f)</c>.
        /// </summary>
        public static FloatRange negative => new(float.MinValue, 0f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(float.MinValue, float.MaxValue)</c>.
        /// </summary>
        public static FloatRange minMax => new(float.MinValue, float.MaxValue);

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private float m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private float m_Max;

        /// <inheritdoc/>
        public float min
        {
            readonly get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public float max
        {
            readonly get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public readonly float Delta => max - min;

        /// <inheritdoc/>
        public readonly float Median => (min + max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public FloatRange(float min = 0f, float max = 1f)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        public readonly float Random()
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public readonly bool Includes(float value)
        {
            return value >= min && value <= max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public readonly bool Includes(float value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(min, max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public readonly float Clamp(float value)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <inheritdoc/>
        public readonly float Lerp(float t)
        {
            return Mathf.Lerp(min, max, t);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public readonly float InverseLerp(float value)
        {
            return Mathf.InverseLerp(min, max, value);
        }

    }

}
