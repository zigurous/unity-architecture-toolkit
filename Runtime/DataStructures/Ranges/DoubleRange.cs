using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of double values.
    /// </summary>
    [System.Serializable]
    public struct DoubleRange
    {
        /// <summary>
        /// Shorthand for writing <c>DoubleRange(0.0, 0.0)</c>.
        /// </summary>
        public static DoubleRange zero => new(0.0, 0.0);

        /// <summary>
        /// Shorthand for writing <c>DoubleRange(1.0, 1.0)</c>.
        /// </summary>
        public static DoubleRange one => new(1.0, 1.0);

        /// <summary>
        /// Shorthand for writing <c>DoubleRange(0.0, 1.0)</c>.
        /// </summary>
        public static DoubleRange percent => new(0.0, 1.0);

        /// <summary>
        /// Shorthand for writing <c>DoubleRange(0.0, double.MaxValue)</c>.
        /// </summary>
        public static DoubleRange positive => new(0.0, double.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>DoubleRange(double.MinValue, 0.0)</c>.
        /// </summary>
        public static DoubleRange negative => new(double.MinValue, 0.0);

        /// <summary>
        /// Shorthand for writing <c>DoubleRange(double.MinValue, double.MaxValue)</c>.
        /// </summary>
        public static DoubleRange minMax => new(double.MinValue, double.MaxValue);

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private double m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private double m_Max;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public double min
        {
            readonly get => m_Min;
            set => m_Min = value;
        }

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public double max
        {
            readonly get => m_Max;
            set => m_Max = value;
        }

        /// <summary>
        /// The difference between the maximum and minimum values (Read only).
        /// </summary>
        public readonly double Delta => max - min;

        /// <summary>
        /// The median value of the range (Read only).
        /// </summary>
        public readonly double Median => (min + max) / 2.0;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public DoubleRange(double min = 0.0, double max = 1.0)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <summary>
        /// Checks if a value is in the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the value is in the range, false otherwise.</returns>
        public readonly bool Includes(double value)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Checks if a value is in the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="includeMin">The minimum value is inclusive if true, exclusive if false.</param>
        /// <param name="includeMax">The maximum value is inclusive if true, exclusive if false.</param>
        /// <returns>True if the value is in the range, false otherwise.</returns>
        public readonly bool Includes(double value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(min, max, includeMin, includeMax);
        }

        /// <summary>
        /// Clamps a value to the range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value.</returns>
        public readonly double Clamp(double value)
        {
            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Linearly interpolates between the range by <paramref name="t"/>.
        /// </summary>
        /// <param name="t">The interpolant value between [0..1].</param>
        /// <returns>The interpolated value.</returns>
        public readonly double Lerp(double t)
        {
            t = t < 0.0 ? 0.0 : (t > 1.0 ? 1.0 : t);
            return min + (max - min) * t;
        }

        /// <summary>
        /// Calculates the linear parameter t that produces the interpolant
        /// value within the range.
        /// </summary>
        /// <param name="value">The value within the range you want to calculate.</param>
        /// <returns>The interpolant value between [0..1].</returns>
        public readonly double InverseLerp(double value)
        {
            double t = (value - min) / (max - min);
            return t < 0.0 ? 0.0 : (t > 1.0 ? 1.0 : t);
        }

    }

}
