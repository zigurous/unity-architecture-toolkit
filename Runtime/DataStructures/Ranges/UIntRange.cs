using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of uint values.
    /// </summary>
    [System.Serializable]
    public struct UIntRange : INumberRange<uint>
    {
        /// <summary>
        /// Shorthand for writing <c>UIntRange(0, 0)</c>.
        /// </summary>
        public static UIntRange zero => new UIntRange(0, 0);

        /// <summary>
        /// Shorthand for writing <c>UIntRange(1, 1)</c>.
        /// </summary>
        public static UIntRange one => new UIntRange(1, 1);

        /// <summary>
        /// Shorthand for writing <c>UIntRange(uint.MinValue, uint.MaxValue)</c>.
        /// </summary>
        public static UIntRange minMax => new UIntRange(uint.MinValue, uint.MaxValue);

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private uint m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private uint m_Max;

        /// <inheritdoc/>
        public uint min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public uint max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public uint delta => max - min;

        /// <inheritdoc/>
        public uint median => (min + max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public UIntRange(uint min, uint max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, exclusive).
        /// </summary>
        /// <returns>A random value in the range [inclusive, exclusive).</returns>
        public uint Random()
        {
            return (uint)UnityEngine.Random.Range((int)min, (int)max);
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, inclusive].
        /// </summary>
        /// <returns>A random value in the range [inclusive, inclusive].</returns>
        public uint RandomInclusive()
        {
            return (uint)UnityEngine.Random.Range((int)min, (int)max + 1);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(uint value)
        {
            return value >= min && value < max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(uint value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(min, max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public uint Clamp(uint value)
        {
            return value < min ? min : (value > max ? max : value);
        }

        /// <inheritdoc/>
        public uint Lerp(float t)
        {
            return (uint)Mathf.Lerp(min, max, t);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public float InverseLerp(uint value)
        {
            return Mathf.InverseLerp(min, max, value);
        }

    }

}
