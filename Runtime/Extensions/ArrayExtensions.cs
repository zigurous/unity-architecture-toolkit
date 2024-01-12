using System;
using System.Collections.Generic;
using System.Text;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for arrays.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// A reusable string builder.
        /// </summary>
        private static StringBuilder stringBuilder;

        /// <summary>
        /// Appends an element to the end of the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>x
        /// <param name="array">The array to add the element to.</param>
        /// <param name="element">The element to add.</param>
        /// <returns>A new array with the added element.</returns>
        public static T[] Append<T>(this T[] array, T element)
        {
            T[] combinedArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++) {
                combinedArray[i] = array[i];
            }

            combinedArray[array.Length] = element;

            return combinedArray;
        }

        /// <summary>
        /// Concats an array of elements to the end of the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to add the elements to.</param>
        /// <param name="elements">The elements to add.</param>
        /// <returns>A new array with the added elements.</returns>
        public static T[] Concat<T>(this T[] array, T[] elements)
        {
            if (elements.Length == 0) {
                return array;
            }

            T[] combinedArray = new T[array.Length + elements.Length];

            for (int i = 0; i < array.Length; i++) {
                combinedArray[i] = array[i];
            }

            for (int i = 0; i < elements.Length; i++) {
                combinedArray[array.Length + i] = elements[i];
            }

            return combinedArray;
        }

        /// <summary>
        /// Checks if the array contains the given element.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <returns>True if the array contains the element, false otherwise.</returns>
        public static bool Contains<T>(this T[] array, T element)
            where T : IEquatable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(element)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the array contains an element that satisfies a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search in.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>True if any element satisfies the predicate.</returns>
        public static bool Contains<T>(this T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]) == true) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the array contains all elements that satisfy a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search in.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>True if all elements satisfy the predicate.</returns>
        public static bool ContainsAll<T>(this T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]) == false) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the element at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search in.</param>
        /// <param name="index">The index of the element to return.</param>
        /// <returns>The element at the specified index, or <c>default</c> if the array is empty.</returns>
        public static T ElementAt<T>(this T[] array, int index)
        {
            if (index >= 0 && index < array.Length) {
                return array[index];
            } else {
                return default;
            }
        }

        /// <summary>
        /// Filters the array to only contain elements that satisfy a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>A new array with the filtered elements removed.</returns>
        public static T[] Filter<T>(this T[] array, Predicate<T> predicate)
        {
            List<T> list = new(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                T element = array[i];

                if (predicate(element) == true) {
                    list.Add(element);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Returns the first element in the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to get the element from.</param>
        /// <returns>The first element in the array, or <c>default</c> if the array is empty.</returns>
        public static T First<T>(this T[] array)
        {
            if (array.Length > 0) {
                return array[0];
            } else {
                return default;
            }
        }

        /// <summary>
        /// Returns the first element in the array that satisfies a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to get the element from.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>The first element in the array that satisfies the predicate, or <c>default</c> if no element satisfies the predicate.</returns>
        public static T First<T>(this T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                T element = array[i];

                if (predicate(element) == true) {
                    return element;
                }
            }

            return default;
        }

        /// <summary>
        /// Returns the first non-null element in the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to get the element from.</param>
        /// <returns>The first non-null element in the array, or <c>default</c> if all elements are null.</returns>
        public static T FirstNonNull<T>(this T[] array) where T : class
        {
            for (int i = 0; i < array.Length; i++)
            {
                T element = array[i];

                if (element != null) {
                    return element;
                }
            }

            return default;
        }

        /// <summary>
        /// Flattens a two-dimensional array into a new one-dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The two-dimensional array to flatten.</param>
        /// <returns>A new array with the flattened elements.</returns>
        public static T[] Flatten<T>(this T[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            T[] flat = new T[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    T element = array[x, y];
                    flat[x * width + y] = element;
                }
            }

            return flat;
        }

        /// <summary>
        /// Flattens a three-dimensional array into a new one-dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The three-dimensional array to flatten.</param>
        /// <returns>A new array with the flattened elements.</returns>
        public static T[] Flatten<T>(this T[,,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);
            int depth = array.GetLength(2);

            T[] flat = new T[width * height * depth];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        T element = array[x, y, z];
                        flat[x + width * (y + height * z)] = element;
                    }
                }
            }

            return flat;
        }

        /// <summary>
        /// Invokes an action for each element in the array. The element and
        /// index are passed as parameters.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to iterate over.</param>
        /// <param name="action">The action to invoke.</param>
        public static void For<T>(this T[] array, Action<(T element, int index)> action)
        {
            for (int i = 0; i < array.Length; i++) {
                action((array[i], i));
            }
        }

        /// <summary>
        /// Invokes an action for each element in the array. The element is
        /// passed as a parameter.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to iterate over.</param>
        /// <param name="action">The action to invoke.</param>
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            for (int i = 0; i < array.Length; i++) {
                action(array[i]);
            }
        }

        /// <summary>
        /// Returns the index of the given element in the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <returns>The index of the element in the array.</returns>
        public static int IndexOf<T>(this T[] array, T element)
            where T : IEquatable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(element)) {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Returns the index of the first element in the array that satisfies
        /// the predicate.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search in.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>The index of the element, or -1 if not found.</returns>
        public static int IndexOf<T>(this T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]) == true) {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Checks if the array is empty.
        /// </summary>
        /// <param name="array">The array to check.</param>
        /// <returns>True if the array is empty.</returns>
        public static bool IsEmpty(this Array array)
        {
            return array.Length <= 0;
        }

        /// <summary>
        /// Checks if the array is not empty.
        /// </summary>
        /// <param name="array">The array to check.</param>
        /// <returns>True if the array is not empty.</returns>
        public static bool IsNotEmpty(this Array array)
        {
            return array.Length > 0;
        }

        /// <summary>
        /// Checks if the specified index is within the bounds of the array.
        /// </summary>
        /// <param name="array">The array to check.</param>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is within the bounds of the array.</returns>
        public static bool IsInBounds(this Array array, int index)
        {
            return index >= 0 && index < array.Length;
        }

        /// <summary>
        /// Checks if the specified index is out of bounds of the array.
        /// </summary>
        /// <param name="array">The array to check.</param>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is out of bounds of the array.</returns>
        public static bool IsNotInBounds(this Array array, int index)
        {
            return index < 0 || index >= array.Length;
        }

        /// <summary>
        /// Joins the elements of the array into a string with a delimiter.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to join.</param>
        /// <param name="delimiter">The delimiter to use.</param>
        /// <param name="startIndex">The index to start at.</param>
        /// <param name="endIndex">The index to end at.</param>
        /// <returns>The joined string.</returns>
        public static string Join<T>(this T[] array, string delimiter, int startIndex = 0, int endIndex = int.MaxValue)
        {
            if (array.Length == 0) {
                return "";
            }

            if (stringBuilder == null) {
                stringBuilder = new StringBuilder();
            } else {
                stringBuilder.Clear();
            }

            int start = Math.Max(0, startIndex);
            int end = Math.Min(array.Length - 1, endIndex - 1);

            for (int i = start; i < end; i++) {
                stringBuilder.Append(array[i]).Append(delimiter);
            }

            stringBuilder.Append(array[end]);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns the last element in the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to get the element from.</param>
        /// <returns>The last element in the array, or <c>default</c> if the array is empty.</returns>
        public static T Last<T>(this T[] array)
        {
            if (array.Length > 0) {
                return array[^1];
            } else {
                return default;
            }
        }

        /// <summary>
        /// Returns the last element in the array that satisfies a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to get the element from.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>The last element in the array that satisfies the predicate, or <c>default</c> if no element satisfies the predicate.</returns>
        public static T Last<T>(this T[] array, Predicate<T> predicate)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                T element = array[i];

                if (predicate(element) == true) {
                    return element;
                }
            }

            return default;
        }

        /// <summary>
        /// Returns the last non-null element in the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to get the element from.</param>
        /// <returns>The last non-null element in the array, or <c>default</c> if all elements are null.</returns>
        public static T LastNonNull<T>(this T[] array) where T : class
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                T element = array[i];

                if (element != null) {
                    return element;
                }
            }

            return default;
        }

        /// <summary>
        /// Maps the elements of the array to a new array using a converter
        /// function.
        /// </summary>
        /// <typeparam name="TInput">The type of the input array.</typeparam>
        /// <typeparam name="TOutput">The type of the output array.</typeparam>
        /// <param name="array">The array to map.</param>
        /// <param name="converter">The converter to use.</param>
        /// <returns>A new array with the converted elements.</returns>
        public static TOutput[] Map<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
        {
            TOutput[] output = new TOutput[array.Length];

            for (int i = 0; i < array.Length; i++) {
                output[i] = converter(array[i]);
            }

            return output;
        }

        /// <summary>
        /// Filters out all null elements from the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to filter.</param>
        /// <returns>A new array with all null elements removed.</returns>
        public static T[] NonNull<T>(this T[] array) where T : class
        {
            if (array.Length > 0) {
                return Filter(array, element => element != null);
            } else {
                return array;
            }
        }

        /// <summary>
        /// Returns a random element from the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to get the random element from.</param>
        /// <returns>A random element from the array, or <c>default</c> if the array is empty.</returns>
        public static T Random<T>(this T[] array)
        {
            if (array.Length > 0) {
                return array[UnityEngine.Random.Range(0, array.Length)];
            } else {
                return default;
            }
        }

        /// <summary>
        /// A function delegate that reduces an array into a single value.
        /// </summary>
        /// <typeparam name="TSum">The type of the reduced value.</typeparam>
        /// <typeparam name="TElement">The type of elements in the array.</typeparam>
        /// <param name="sum">The current sum.</param>
        /// <param name="element">The current element being reduced.</param>
        /// <returns>The reduced value.</returns>
        public delegate TSum Reducer<TSum, TElement>(TSum sum, TElement element);

        /// <summary>
        /// Reduces the elements of the array to a single value.
        /// </summary>
        /// <typeparam name="TSum">The type of the reduced value.</typeparam>
        /// <typeparam name="TElement">The type of elements in the array.</typeparam>
        /// <param name="array">The array to reduce.</param>
        /// <param name="initialValue">The initial value to use.</param>
        /// <param name="reducer">The reducer to use.</param>
        /// <returns>The reduced value.</returns>
        public static TSum Reduce<TElement, TSum>(this TElement[] array, TSum initialValue, Reducer<TSum, TElement> reducer)
        {
            TSum sum = initialValue;

            for (int i = 0; i < array.Length; i++) {
                sum = reducer(sum, array[i]);
            }

            return sum;
        }

        /// <summary>
        /// Removes the element at the specified index from the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to remove the element from.</param>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>A new array with the element removed.</returns>
        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            if (index < 0 || index >= array.Length) {
                return array;
            }

            T[] removed = new T[array.Length - 1];

            if (index > 0) {
                Array.Copy(array, 0, removed, 0, index);
            }

            if (index < array.Length - 1) {
                Array.Copy(array, index + 1, removed, index, array.Length - index - 1);
            }

            return removed;
        }

        /// <summary>
        /// Reverses the order of the elements in the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to reverse.</param>
        public static void Reverse<T>(this T[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                T temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Reverses the order of the elements in the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to reverse.</param>
        /// <returns>A new array with the order of the elements reversed.</returns>
        public static T[] Reversed<T>(this T[] array)
        {
            T[] reversed = new T[array.Length];

            for (int i = 0, j = array.Length - 1; i < array.Length; i++, j--) {
                reversed[i] = array[j];
            }

            return reversed;
        }

        /// <summary>
        /// Shuffles the array in place.
        /// </summary>
        /// <remarks>The shuffle is done using the Fisher-Yates algorithm.</remarks>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to shuffle.</param>
        public static void Shuffle<T>(this T[] array)
        {
            int n = array.Length;

            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        /// <summary>
        /// Shuffles the array in place using the given random number generator.
        /// </summary>
        /// <remarks>The shuffle is done using the Fisher-Yates algorithm.</remarks>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to shuffle.</param>
        /// <param name="rng">The random number generator to use.</param>
        public static void Shuffle<T>(this T[] array, Random rng)
        {
            int n = array.Length;

            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        /// <summary>
        /// Returns a portion of the array containing a specified amount of
        /// elements.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to slice.</param>
        /// <param name="amount">The amount of elements to slice.</param>
        /// <returns>A new array containing only the sliced elements.</returns>
        public static T[] Slice<T>(this T[] array, int amount)
        {
            T[] slice = new T[amount];

            for (int i = 0; i < amount; i++) {
                slice[i] = array[i];
            }

            return slice;
        }

        /// <summary>
        /// Sorts the elements of the array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to sort.</param>
        /// <param name="comparison">The comparison to use.</param>
        public static void Sort<T>(this T[] array, Comparison<T> comparison)
        {
            Array.Sort(array, comparison);
        }

        /// <summary>
        /// Filters the array to only contain elements that satisfy a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>A new array with the filtered elements removed.</returns>
        public static T[] Where<T>(this T[] array, Predicate<T> predicate)
        {
            return Filter(array, predicate);
        }

        /// <summary>
        /// Wraps an index to either end of the array if it is out of bounds.
        /// </summary>
        /// <param name="array">The array to wrap.</param>
        /// <param name="index">The index to wrap.</param>
        /// <returns>The wrapped index.</returns>
        public static int WrapIndex(this Array array, int index)
        {
            return ((index % array.Length) + array.Length) % array.Length;
        }

    }

}
