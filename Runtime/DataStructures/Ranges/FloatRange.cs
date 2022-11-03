using UnityEngine;

namespace Zigurous.Architecture.Structs
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
        public static FloatRange zero => new FloatRange(0f, 0f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(1f, 1f)</c>.
        /// </summary>
        public static FloatRange one => new FloatRange(1f, 1f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, 1f)</c>.
        /// </summary>
        public static FloatRange percent => new FloatRange(0f, 1f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, float.MaxValue)</c>.
        /// </summary>
        public static FloatRange positive => new FloatRange(0f, float.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(float.MinValue, 0f)</c>.
        /// </summary>
        public static FloatRange negative => new FloatRange(float.MinValue, 0f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(float.MinValue, float.MaxValue)</c>.
        /// </summary>
        public static FloatRange minMax => new FloatRange(float.MinValue, float.MaxValue);

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private float m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private float m_Max;

        /// <inheritdoc/>
        public float min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public float max
        {
            get => m_Max;
            set => m_Max = value;
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
        public FloatRange(float min = 0f, float max = 1f)
        {
            m_Min = min;
            m_Max = max;
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
