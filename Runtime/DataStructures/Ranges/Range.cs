using System;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of values of the given type.
    /// </summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    [System.Serializable]
    public struct Range<T> : IRange<T> where T : IComparable<T>
    {
        private T m_Min;
        private T m_Max;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public T min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public T max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Range(T min = default(T), T max = default(T))
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(T value)
        {
            return value.IsBetween(min, max, true, true);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(T value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(min, max, includeMin, includeMax);
        }

    }

}
