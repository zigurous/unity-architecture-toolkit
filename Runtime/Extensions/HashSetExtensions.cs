﻿using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for hash sets.
    /// </summary>
    public static class HashSetExtensions
    {
        /// <summary>
        /// Returns the first element in the set that satisifies a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the set.</typeparam>
        /// <param name="set">The set to get the element from.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>The first element in the set that satisifies the predicate.</returns>
        public static T First<T>(this HashSet<T> set, Predicate<T> predicate)
        {
            foreach (T element in set)
            {
                if (predicate(element) == true) {
                    return element;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Invokes an action on each element in the set. The element is passed
        /// as a parameter.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the set.</typeparam>
        /// <param name="set">The set to iterate over.</param>
        /// <param name="action">The action to invoke on each element.</param>
        public static void ForEach<T>(this HashSet<T> set, Action<T> action)
        {
            foreach (T item in set) {
                action(item);
            }
        }

        /// <summary>
        /// Checks if any element in the set satisfies a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the set.</typeparam>
        /// <param name="set">The set to check.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>True if any element in the set satisfies the predicate.</returns>
        public static bool IsAny<T>(this HashSet<T> set, Predicate<T> predicate)
        {
            foreach (T item in set)
            {
                if (predicate(item)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if each element in the set satisfies a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the set.</typeparam>
        /// <param name="set">The set to check.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>True if all elements in the set satisfy the predicate.</returns>
        public static bool IsEach<T>(this HashSet<T> set, Predicate<T> predicate)
        {
            foreach (T item in set)
            {
                if (!predicate(item)) {
                    return false;
                }
            }

            return true;
        }

    }

}
