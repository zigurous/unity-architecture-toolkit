using System;
using System.Text.RegularExpressions;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Handles escaping and unescaping paths.
    /// </summary>
    public static class PathEscaper
    {
        private static string m_EscapeCharacter = "__";
        private static string m_InvalidCharacters = @"""\/?:;<>*|.+";

        private static Regex m_EscapeRegex;
        private static Regex m_UnescapeRegex;

        /// <summary>
        /// The default escape character to use.
        /// </summary>
        public static string escapeCharacter
        {
            get => m_EscapeCharacter;
            set
            {
                if (m_EscapeCharacter != value)
                {
                    m_EscapeCharacter = value;
                    m_EscapeRegex = EscapeRegex(m_EscapeCharacter, m_InvalidCharacters);
                    m_UnescapeRegex = UnescapeRegex(m_EscapeCharacter);
                }
            }
        }

        /// <summary>
        /// The default invalid characters to escape.
        /// </summary>
        public static string invalidCharacters
        {
            get => m_InvalidCharacters;
            set
            {
                if (m_InvalidCharacters != value)
                {
                    m_InvalidCharacters = value;
                    m_EscapeRegex = EscapeRegex(m_EscapeCharacter, m_InvalidCharacters);
                }
            }
        }

        /// <summary>
        /// Escapes the path.
        /// </summary>
        /// <param name="path">The path to escape.</param>
        /// <returns>The escaped path.</returns>
        public static string Escape(string path)
        {
            m_EscapeRegex ??= EscapeRegex(m_EscapeCharacter, m_InvalidCharacters);
            return m_EscapeRegex.Replace(path, m => m_EscapeCharacter + ((short)m.Value[0]).ToString("X4"));
        }

        /// <summary>
        /// Escapes the path.
        /// </summary>
        /// <param name="path">The path to escape.</param>
        /// <param name="regex">The escape regex to use.</param>
        /// <param name="escapeCharacter">The character used to replace invalid characters, e.g. "_".</param>
        /// <returns>The escaped path.</returns>
        public static string Escape(string path, Regex regex, string escapeCharacter)
        {
            return regex.Replace(path, m => escapeCharacter + ((short)m.Value[0]).ToString("X4"));
        }

        /// <summary>
        /// Creates a regex for escaping paths.
        /// </summary>
        /// <param name="escapeCharacter">The character used to replace invalid characters, e.g. "_".</param>
        /// <param name="invalidCharacters">The invalid characters that will be replaced by the escaped character.</param>
        /// <returns>The escape regex.</returns>
        public static Regex EscapeRegex(string escapeCharacter, string invalidCharacters)
        {
            return new Regex(
                "[" + Regex.Escape(escapeCharacter + invalidCharacters) + "]",
                RegexOptions.Compiled);
        }

        /// <summary>
        /// Unescapes the path.
        /// </summary>
        /// <param name="path">The path to unescape.</param>
        /// <returns>The unescaped path.</returns>
        public static string Unescape(string path)
        {
            m_UnescapeRegex ??= UnescapeRegex(m_EscapeCharacter);
            return m_UnescapeRegex.Replace(path, m => ((char)Convert.ToInt16(m.Groups[1].Value, 16)).ToString());
        }

        /// <summary>
        /// Unescapes the path.
        /// </summary>
        /// <param name="path">The path to unescape.</param>
        /// <param name="regex">The unescape regex to use.</param>
        /// <returns>The unescaped path.</returns>
        public static string Unescape(string path, Regex regex)
        {
            return regex.Replace(path, m => ((char)Convert.ToInt16(m.Groups[1].Value, 16)).ToString());
        }

        /// <summary>
        /// Creates a regex for unescaping paths.
        /// </summary>
        /// <param name="escapeCharacter">The character used to replace invalid characters, e.g. "_".</param>
        /// <returns>The unescape regex.</returns>
        public static Regex UnescapeRegex(string escapeCharacter)
        {
            return new Regex(
                Regex.Escape(escapeCharacter) + "([0-9A-Z]{4})",
                RegexOptions.Compiled);
        }

    }

}
