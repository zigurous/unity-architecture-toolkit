using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of Vector2Int values.
    /// </summary>
    [System.Serializable]
    public struct Vector2IntRange : INumberRange<Vector2Int>
    {
        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private Vector2Int m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private Vector2Int m_Max;

        /// <inheritdoc/>
        public Vector2Int min
        {
            readonly get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public Vector2Int max
        {
            readonly get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public readonly Vector2Int Delta => max - min;

        /// <inheritdoc/>
        public readonly Vector2Int Median => (min + max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector2IntRange(Vector2Int min, Vector2Int max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        public readonly Vector2Int Random()
        {
            return new Vector2Int(
                UnityEngine.Random.Range(min.x, max.x + 1),
                UnityEngine.Random.Range(min.y, max.y + 1));
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public readonly bool Includes(Vector2Int value)
        {
            return value.x >= min.x && value.x <= max.x &&
                   value.y >= min.y && value.y <= max.y;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public readonly bool Includes(Vector2Int value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(min.x, max.x, includeMin, includeMax) &&
                   value.y.IsBetween(min.y, max.y, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public readonly Vector2Int Clamp(Vector2Int value)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            return value;
        }

        /// <inheritdoc/>
        public readonly Vector2Int Lerp(float t)
        {
            Vector2 lerp = Vector2.Lerp(min, max, t);
            return new Vector2Int((int)lerp.x, (int)lerp.y);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public readonly float InverseLerp(Vector2Int value)
        {
            Vector2 AB = max - min;
            Vector2 AV = value - min;

            return Mathf.Clamp01(Vector2.Dot(AV, AB) / Vector2.Dot(AB, AB));
        }

    }

}
