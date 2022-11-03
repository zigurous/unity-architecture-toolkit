using UnityEngine;

namespace Zigurous.Architecture.Structs
{
    /// <summary>
    /// A range of Vector3 values.
    /// </summary>
    [System.Serializable]
    public struct Vector3Range : INumberRange<Vector3>
    {
        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private Vector3 m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private Vector3 m_Max;

        /// <inheritdoc/>
        public Vector3 min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public Vector3 max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public Vector3 delta => max - min;

        /// <inheritdoc/>
        public Vector3 median => (min + max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector3Range(Vector3 min, Vector3 max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        public Vector3 Random()
        {
            return new Vector3(
                UnityEngine.Random.Range(min.x, max.x),
                UnityEngine.Random.Range(min.y, max.y),
                UnityEngine.Random.Range(min.z, max.z));
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector3 value)
        {
            return value.x >= min.x && value.x <= max.x &&
                   value.y >= min.y && value.y <= max.y &&
                   value.z >= min.z && value.z <= max.z;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector3 value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(min.x, max.x, includeMin, includeMax) &&
                   value.y.IsBetween(min.y, max.y, includeMin, includeMax) &&
                   value.z.IsBetween(min.z, max.z, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public Vector3 Clamp(Vector3 value)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            value.z = Mathf.Clamp(value.z, min.z, max.z);
            return value;
        }

        /// <inheritdoc/>
        public Vector3 Lerp(float t)
        {
            return Vector3.Lerp(min, max, t);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public float InverseLerp(Vector3 value)
        {
            Vector3 AB = max - min;
            Vector3 AV = value - min;

            return Mathf.Clamp01(Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB));
        }

    }

}
