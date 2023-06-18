using UnityEngine;

namespace Zigurous.Architecture.Structs
{
    /// <summary>
    /// A range of int values.
    /// </summary>
    [System.Serializable]
    public struct IntRange : INumberRange<int>
    {
        /// <summary>
        /// Shorthand for writing <c>IntRange(0, 0)</c>.
        /// </summary>
        public static IntRange zero => new IntRange(0, 0);

        /// <summary>
        /// Shorthand for writing <c>IntRange(1, 1)</c>.
        /// </summary>
        public static IntRange one => new IntRange(1, 1);

        /// <summary>
        /// Shorthand for writing <c>IntRange(0, int.MaxValue)</c>.
        /// </summary>
        public static IntRange positive => new IntRange(0, int.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>IntRange(int.MinValue, 0)</c>.
        /// </summary>
        public static IntRange negative => new IntRange(int.MinValue, 0);

        /// <summary>
        /// Shorthand for writing <c>IntRange(int.MinValue, int.MaxValue)</c>.
        /// </summary>
        public static IntRange minMax => new IntRange(int.MinValue, int.MaxValue);

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private int m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private int m_Max;

        /// <inheritdoc/>
        public int min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public int max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public int delta => max - min;

        /// <inheritdoc/>
        public int median => (min + max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public IntRange(int min, int max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, exclusive).
        /// </summary>
        /// <returns>A random value in the range [inclusive, exclusive).</returns>
        public int Random()
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, inclusive].
        /// </summary>
        /// <returns>A random value in the range [inclusive, inclusive].</returns>
        public int RandomInclusive()
        {
            return UnityEngine.Random.Range(min, max + 1);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(int value)
        {
            return value >= min && value < max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(int value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(min, max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public int Clamp(int value)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <inheritdoc/>
        public int Lerp(float t)
        {
            return (int)Mathf.Lerp(min, max, t);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public float InverseLerp(int value)
        {
            return Mathf.InverseLerp(min, max, value);
        }

    }

}
