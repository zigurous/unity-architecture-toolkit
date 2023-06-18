using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of values between zero and one.
    /// </summary>
    [System.Serializable]
    public struct UnitIntervalRange : INumberRange<float>
    {
        /// <summary>
        /// Shorthand for writing <c>UnitIntervalRange(0f, 0f)</c>.
        /// </summary>
        public static UnitIntervalRange zero => new UnitIntervalRange(0f, 0f);

        /// <summary>
        /// Shorthand for writing <c>UnitIntervalRange(1f, 1f)</c>.
        /// </summary>
        public static UnitIntervalRange one => new UnitIntervalRange(1f, 1f);

        /// <summary>
        /// Shorthand for writing <c>UnitIntervalRange(0f, 1f)</c>.
        /// </summary>
        public static UnitIntervalRange minMax => new UnitIntervalRange(0f, 1f);

        [SerializeField]
        [Range(0f, 1f)]
        [Tooltip("The lower bound of the range.")]
        private float m_Min;

        [SerializeField]
        [Range(0f, 1f)]
        [Tooltip("The upper bound of the range.")]
        private float m_Max;

        /// <inheritdoc/>
        public float min
        {
            get => m_Min;
            set => m_Min = Mathf.Clamp01(value);
        }

        /// <inheritdoc/>
        public float max
        {
            get => m_Max;
            set => m_Max = Mathf.Clamp01(value);
        }

        /// <inheritdoc/>
        public float Delta => max - min;

        /// <inheritdoc/>
        public float Median => (min + max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public UnitIntervalRange(float min = 0f, float max = 1f)
        {
            m_Min = Mathf.Clamp01(min);
            m_Max = Mathf.Clamp01(max);
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
