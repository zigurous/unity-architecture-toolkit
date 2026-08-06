using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Caches strings to minimize GC allocations. Useful when repeatably
    /// formatting the same strings.
    /// </summary>
    public static class StringCache<T>
    {
        private static Dictionary<T, string> cache1;
        private static Dictionary<string, Dictionary<T, string>> cache2;

        public static string Format(T value, Func<T, string> formatter = null)
        {
            cache1 ??= new Dictionary<T, string>();

            if (cache1.TryGetValue(value, out string cachedString)) {
                return cachedString;
            }

            string formattedString;

            if (formatter != null) {
                formattedString = formatter(value);
            } else {
                formattedString = value.ToString();
            }

            cache1[value] = formattedString;

            return formattedString;
        }

        public static string Format(T value, string format, Func<T, string> formatter = null)
        {
            cache2 ??= new Dictionary<string, Dictionary<T, string>>();

            if (!cache2.ContainsKey(format)) {
                cache2.Add(format, new Dictionary<T, string>());
            }

            Dictionary<T, string> cache = cache2[format];

            if (cache.TryGetValue(value, out string cachedString)) {
                return cachedString;
            }

            string formattedString;

            if (formatter != null) {
                formattedString = formatter(value);
            } else {
                formattedString = string.Format(format, value);
            }

            cache[value] = formattedString;

            return formattedString;
        }

        public static void Remove(T value)
        {
            if (cache1 != null && cache1.ContainsKey(value)) {
                cache1.Remove(value);
            }
        }

        public static void Remove(T value, string format)
        {
            if (cache2 != null && cache2.TryGetValue(format, out Dictionary<T, string> cache))
            {
                if (cache.ContainsKey(value)) {
                    cache.Remove(value);
                }
            }
        }

        public static void Clear()
        {
            cache1?.Clear();
            cache2?.Clear();
        }

    }

}
