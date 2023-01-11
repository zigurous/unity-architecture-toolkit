using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of Vector4 values.
    /// </summary>
    [System.Serializable]
    public struct Vector4Range : INumberRange<Vector4>
    {
        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private Vector4 m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private Vector4 m_Max;

        /// <inheritdoc/>
        public Vector4 min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public Vector4 max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public Vector4 Delta => max - min;

        /// <inheritdoc/>
        public Vector4 Median => (min + max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector4Range(Vector4 min, Vector4 max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        public Vector4 Random()
        {
            return new Vector4(
                UnityEngine.Random.Range(min.x, max.x),
                UnityEngine.Random.Range(min.y, max.y),
                UnityEngine.Random.Range(min.z, max.z),
                UnityEngine.Random.Range(min.w, max.w));
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector4 value)
        {
            return value.x >= min.x && value.x <= max.x &&
                   value.y >= min.y && value.y <= max.y &&
                   value.z >= min.z && value.z <= max.z &&
                   value.w >= min.w && value.w <= max.w;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector4 value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(min.x, max.x, includeMin, includeMax) &&
                   value.y.IsBetween(min.y, max.y, includeMin, includeMax) &&
                   value.z.IsBetween(min.z, max.z, includeMin, includeMax) &&
                   value.w.IsBetween(min.w, max.w, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public Vector4 Clamp(Vector4 value)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            value.z = Mathf.Clamp(value.z, min.z, max.z);
            value.w = Mathf.Clamp(value.w, min.w, max.w);
            return value;
        }

        /// <inheritdoc/>
        public Vector4 Lerp(float t)
        {
            return Vector4.Lerp(min, max, t);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public float InverseLerp(Vector4 value)
        {
            Vector4 AB = max - min;
            Vector4 AV = value - min;

            return Vector4.Dot(AV, AB) / Vector4.Dot(AB, AB);
        }

    }

}
