using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A range of Color values.
    /// </summary>
    [System.Serializable]
    public struct ColorRange : INumberRange<Color>
    {
        /// <summary>
        /// Shorthand for writing <c>ColorRange(Color.black, Color.black)</c>.
        /// </summary>
        public static ColorRange black => new ColorRange(Color.black, Color.black);

        /// <summary>
        /// Shorthand for writing <c>ColorRange(Color.white, Color.white)</c>.
        /// </summary>
        public static ColorRange white => new ColorRange(Color.white, Color.white);

        /// <summary>
        /// Shorthand for writing <c>ColorRange(Color.black, Color.white)</c>.
        /// </summary>
        public static ColorRange blackToWhite => new ColorRange(Color.black, Color.white);

        /// <summary>
        /// Shorthand for writing <c>ColorRange(Color.white, Color.black)</c>.
        /// </summary>
        public static ColorRange whiteToBlack => new ColorRange(Color.white, Color.black);

        /// <summary>
        /// Shorthand for writing <c>ColorRange(Color(0,0,0,0), Color(0,0,0,1))</c>.
        /// </summary>
        public static ColorRange fadeIn => new ColorRange(new Color(0f, 0f, 0f, 0f), new Color(0f, 0f, 0f, 1f));

        /// <summary>
        /// Shorthand for writing <c>ColorRange(Color(0,0,0,1), Color(0,0,0,0))</c>.
        /// </summary>
        public static ColorRange fadeOut => new ColorRange(new Color(0f, 0f, 0f, 1f), new Color(0f, 0f, 0f, 0f));

        /// <summary>
        /// Shorthand for writing <c>ColorRange(Color(0,0,0,0), Color(0,0,0,0))</c>.
        /// </summary>
        public static ColorRange transparent => new ColorRange(new Color(0f, 0f, 0f, 0f), new Color(0f, 0f, 0f, 0f));

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private Color m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private Color m_Max;

        /// <inheritdoc/>
        public Color min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public Color max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public Color delta => max - min;

        /// <inheritdoc/>
        public Color median => (min + max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public ColorRange(Color min, Color max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        public Color Random()
        {
            return Color.Lerp(min, max, UnityEngine.Random.value);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Color value)
        {
            return value.r >= min.r && value.r <= max.r &&
                   value.g >= min.g && value.g <= max.g &&
                   value.b >= min.b && value.b <= max.b &&
                   value.a >= min.a && value.a <= max.a;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Color value, bool includeMin, bool includeMax)
        {
            return value.r.IsBetween(min.r, max.r, includeMin, includeMax) &&
                   value.g.IsBetween(min.g, max.g, includeMin, includeMax) &&
                   value.b.IsBetween(min.b, max.b, includeMin, includeMax) &&
                   value.a.IsBetween(min.a, max.a, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public Color Clamp(Color value)
        {
            value.r = Mathf.Clamp(value.r, min.r, max.r);
            value.g = Mathf.Clamp(value.g, min.g, max.g);
            value.b = Mathf.Clamp(value.b, min.b, max.b);
            value.a = Mathf.Clamp(value.a, min.a, max.a);
            return value;
        }

        /// <inheritdoc/>
        public Color Lerp(float t)
        {
            return Color.Lerp(min, max, t);
        }

        /// <inheritdoc/>
        /// <param name="value">The value within the range you want to calculate.</param>
        public float InverseLerp(Color value)
        {
            Vector4 AB = max - min;
            Vector4 AV = value - min;
            return Vector4.Dot(AV, AB) / Vector4.Dot(AB, AB);
        }

    }

}
