using UnityEngine;

namespace Zigurous.Architecture.Structs
{
    /// <summary>
    /// A range of Vector3Int values.
    /// </summary>
    [System.Serializable]
    public struct Vector3IntRange : INumberRange<Vector3Int>
    {
        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private Vector3Int m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private Vector3Int m_Max;

        /// <inheritdoc/>
        public Vector3Int min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public Vector3Int max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public Vector3Int delta => max - min;

        /// <inheritdoc/>
        public Vector3Int median => (min + max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector3IntRange(Vector3Int min, Vector3Int max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        public Vector3Int Random()
        {
            return new Vector3Int(
                UnityEngine.Random.Range(min.x, max.x + 1),
                UnityEngine.Random.Range(min.y, max.y + 1),
                UnityEngine.Random.Range(min.z, max.z + 1));
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector3Int value)
        {
            return value.x >= min.x && value.x <= max.x &&
                   value.y >= min.y && value.y <= max.y &&
                   value.z >= min.z && value.z <= max.z;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector3Int value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(min.x, max.x, includeMin, includeMax) &&
                   value.y.IsBetween(min.y, max.y, includeMin, includeMax) &&
                   value.z.IsBetween(min.z, max.z, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public Vector3Int Clamp(Vector3Int value)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            value.z = Mathf.Clamp(value.z, min.z, max.z);
            return value;
        }

        /// <inheritdoc/>
        public Vector3Int Lerp(float t)
        {
            Vector3 lerp = Vector3.Lerp(min, max, t);
            return new Vector3Int((int)lerp.x, (int)lerp.y, (int)lerp.z);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public float InverseLerp(Vector3Int value)
        {
            Vector3 AB = max - min;
            Vector3 AV = value - min;

            return Mathf.Clamp01(Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB));
        }

    }

}
