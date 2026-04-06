using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Caches strings to minimize GC allocations. Useful when repeatably
    /// formatting the same strings.
    /// </summary>
    public static class StringCache
    {
        private static Dictionary<int, string> integerCache;
        private static Dictionary<string, Dictionary<float, string>> floatCache;
        private static Dictionary<string, Dictionary<DateTime, string>> dateTimeCache;

        public static string Format(int value, Func<int, string> formatter = null)
        {
            integerCache ??= new Dictionary<int, string>();

            if (integerCache.TryGetValue(value, out string cachedString)) {
                return cachedString;
            }

            string formattedString;

            if (formatter != null) {
                formattedString = formatter(value);
            } else {
                formattedString = value.ToString();
            }

            integerCache[value] = formattedString;

            return formattedString;
        }

        public static string Format(float value, string format, Func<float, string> formatter = null)
        {
            floatCache ??= new Dictionary<string, Dictionary<float, string>>();

            if (float.IsNaN(value)) {
                value = 0f;
            }

            if (!floatCache.ContainsKey(format)) {
                floatCache.Add(format, new Dictionary<float, string>());
            }

            Dictionary<float, string> cache = floatCache[format];

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

        public static string Format(DateTime value, string format, Func<DateTime, string> formatter = null)
        {
            dateTimeCache ??= new Dictionary<string, Dictionary<DateTime, string>>();

            if (!dateTimeCache.ContainsKey(format)) {
                dateTimeCache.Add(format, new Dictionary<DateTime, string>());
            }

            Dictionary<DateTime, string> cache = dateTimeCache[format];

            if (cache.TryGetValue(value, out string cachedString)) {
                return cachedString;
            }

            string formattedString;

            if (formatter != null) {
                formattedString = formatter(value);
            } else {
                formattedString = value.ToString(format);
            }

            cache[value] = formattedString;

            return formattedString;
        }

        public static void Remove(int value)
        {
            if (integerCache != null && integerCache.ContainsKey(value)) {
                integerCache.Remove(value);
            }
        }

        public static void Remove(float value, string format)
        {
            if (floatCache != null && floatCache.TryGetValue(format, out Dictionary<float, string> cache))
            {
                if (cache.ContainsKey(value)) {
                    cache.Remove(value);
                }
            }
        }

        public static void Remove(DateTime value, string format)
        {
            if (dateTimeCache != null && dateTimeCache.TryGetValue(format, out Dictionary<DateTime, string> cache))
            {
                if (cache.ContainsKey(value)) {
                    cache.Remove(value);
                }
            }
        }

        public static void Clear()
        {
            integerCache?.Clear();
            floatCache?.Clear();
            dateTimeCache?.Clear();
        }

    }

}
