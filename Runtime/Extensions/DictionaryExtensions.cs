using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Filters the dictionary by a predicate.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>A new dictionary with the filtered key-value pairs removed.</returns>
        public static Dictionary<TKey, TValue> Where<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Predicate<KeyValuePair<TKey, TValue>> predicate)
        {
            Dictionary<TKey, TValue> matches = new Dictionary<TKey, TValue>(dictionary.Count);

            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                if (predicate(pair)) {
                    matches.Add(pair.Key, pair.Value);
                }
            }

            return matches;
        }

        /// <summary>
        /// Filters the dictionary keys by a predicate.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="keys">The keys to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>A new list with the filtered keys removed.</returns>
        public static List<TKey> Where<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection keys, Predicate<TKey> predicate)
        {
            List<TKey> matches = new List<TKey>(keys.Count);

            foreach (TKey key in keys)
            {
                if (predicate(key)) {
                    matches.Add(key);
                }
            }

            return matches;
        }

        /// <summary>
        /// Filters the dictionary values by a predicate.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="values">The values to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>A new list with the filtered values removed.</returns>
        public static List<TValue> Where<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection values, Predicate<TValue> predicate)
        {
            List<TValue> matches = new List<TValue>(values.Count);

            foreach (TValue value in values)
            {
                if (predicate(value)) {
                    matches.Add(value);
                }
            }

            return matches;
        }

    }

}
