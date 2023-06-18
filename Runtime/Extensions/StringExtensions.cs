using System.Globalization;
using System.Text;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// A reusable string builder.
        /// </summary>
        private static StringBuilder stringBuilder;

        /// <summary>
        /// Checks if the string is null or empty.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>True if the string is null or empty.</returns>
        public static bool IsEmpty(this string str)
        {
            return str == null || str.Length <= 0;
        }

        /// <summary>
        /// Checks if the string is not null and not empty.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>True if the string is not null and not empty.</returns>
        public static bool IsNotEmpty(this string str)
        {
            return str != null && str.Length > 0;
        }

        /// <summary>
        /// Repeats the string a given number of times.
        /// </summary>
        /// <param name="str">The string to repeat.</param>
        /// <param name="n">The number of times to repeat the string.</param>
        /// <returns>A new repeated string.</returns>
        public static string Repeat(this string str, int n)
        {
            if (stringBuilder == null) {
                stringBuilder = new StringBuilder();
            } else {
                stringBuilder.Clear();
            }

            stringBuilder.Capacity = str.Length * n;
            stringBuilder.Insert(0, str, n);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Formats the string using title case. If the string is null, then the
        /// default text will be returned instead.
        /// </summary>
        /// <param name="str">The string to format.</param>
        /// <param name="defaultText">An optional string returned if the formatted string is null.</param>
        /// <returns>The formatted string.</returns>
        public static string ToTitleCase(this string str, string defaultText = null)
        {
            if (str == null) {
                return defaultText;
            } else {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
            }
        }

        /// <summary>
        /// Formats the string using title case. If the string is null, then the
        /// default text will be returned instead.
        /// </summary>
        /// <param name="str">The string to format.</param>
        /// <param name="cultureInfo">The localization culture to use when formatting the string.</param>
        /// <param name="defaultText">An optional string returned if the formatted string is null.</param>
        /// <returns>The formatted string.</returns>
        public static string ToTitleCase(this string str, CultureInfo cultureInfo, string defaultText = null)
        {
            if (str == null) {
                return defaultText;
            } else {
                return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
            }
        }

    }

}
