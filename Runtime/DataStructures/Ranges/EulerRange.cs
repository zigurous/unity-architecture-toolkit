using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of euler values wrapped between -360 and +360.
    /// </summary>
    [System.Serializable]
    public struct EulerRange : INumberRange<float>
    {
        /// <summary>
        /// Shorthand for writing <c>EulerRange(0f, 0f)</c>.
        /// </summary>
        public static EulerRange zero => new(0f, 0f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(0f, 180f)</c>.
        /// </summary>
        public static EulerRange pi => new(0f, 180f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(0f, 360f)</c>.
        /// </summary>
        public static EulerRange pi2 => new(0f, 360f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(-180f, 180f)</c>.
        /// </summary>
        public static EulerRange halfRange => new(-180f, 180f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(-360f, 360f)</c>.
        /// </summary>
        public static EulerRange fullRange => new(-360f, 360f);

        [SerializeField]
        [Range(-360f, 360f)]
        [Tooltip("The lower bound of the range.")]
        private float m_Min;

        [SerializeField]
        [Range(-360f, 360f)]
        [Tooltip("The upper bound of the range.")]
        private float m_Max;

        /// <inheritdoc/>
        public float min
        {
            readonly get => m_Min;
            set => m_Min = Wrap(value, -360f, 360f);
        }

        /// <inheritdoc/>
        public float max
        {
            readonly get => m_Max;
            set => m_Max = Wrap(value, -360f, 360f);
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
        public EulerRange(float min = -360f, float max = 360f)
        {
            m_Min = Wrap(min, -360f, 360f);
            m_Max = Wrap(max, -360f, 360f);
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

        /// <summary>
        /// Wraps a value within the range.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <returns>The wrapped value.</returns>
        public readonly float Wrap(float value)
        {
            return Wrap(value, min, max);
        }

        private static float Wrap(float value, float min, float max)
        {
            if (value < min) {
                return max - (min - value) % (max - min);
            } else if (value > max) {
                return min + (value - min) % (max - min);
            } else {
                return value;
            }
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
