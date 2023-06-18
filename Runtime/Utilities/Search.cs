using System;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Implementations of common array search algorithms.
    /// </summary>
    public static class Search
    {
        /// <summary>
        /// Binary search is a searching algorithm used in a sorted array by
        /// repeatedly dividing the search interval in half. The array must be
        /// sorted for the algorithm to work correctly.<br/>
        /// Time Complexity: Best <c>O(1)</c>, Average <c>Θ(log n)</c>, Worst <c>O(log n)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// </summary>
        /// <param name="array">The array to search.</param>
        /// <param name="key">The element to find.</param>
        /// <returns>The index of the key, or -1 if not found.</returns>
        public static int BinarySearch<T>(T[] array, T key)
            where T : IComparable<T>
        {
            int low = 0;
            int high = array.Length - 1;

            // repeat until the low and high index meet each other
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                // check if the key is present at mid
                if (array[mid].CompareTo(key) == 0) {
                    return mid;
                }

                // if the key is greater, ignore the left half
                // if the key is smaller, ignore the right half
                if (array[mid].CompareTo(key) < 0) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Linear search is a sequential searching algorithm where we start
        /// from one end and check every element of the array until the desired
        /// element is found.<br/>
        /// Time Complexity: <c>O(n)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// </summary>
        /// <param name="array">The array to search.</param>
        /// <param name="key">The element to find.</param>
        /// <returns>The index of the key, or -1 if not found.</returns>
        public static int LinearSearch<T>(T[] array, T key)
            where T : IEquatable<T>
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                if (array[i].Equals(key)) {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Sentinel linear search is a type of linear search where the number
        /// of comparisons is reduced as compared to a traditional linear
        /// search. In this search, the last element of the array is replaced
        /// with the element to be searched. This prevents the need to check if
        /// the current index is inside the bounds of the array since the
        /// element to be searched will never be out of bounds.<br/>
        /// Time Complexity: <c>O(n)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// </summary>
        /// <param name="array">The array to search.</param>
        /// <param name="key">The element to find.</param>
        /// <returns>The index of the key, or -1 if not found.</returns>
        public static int SentinelLinearSearch<T>(T[] array, T key)
            where T : IEquatable<T>
        {
            int n = array.Length;

            // store the last element in the array and replace with the key
            T last = array[n - 1];
            array[n - 1] = key;

            int i = 0;

            // iterate until we reach the key (last element)
            // this prevents the need for i < n comparison
            while (!array[i].Equals(key)) {
                i++;
            }

            // put the last element back
            array[n - 1] = last;

            if ((i < n - 1) || last.Equals(key)) {
                return i;
            } else {
                return -1;
            }
        }

    }

}
