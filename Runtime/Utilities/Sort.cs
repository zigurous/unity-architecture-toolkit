using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Implementations of common array sorting algorithms.
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Bubble sort is a comparison-based sorting algorithm that compares
        /// two adjacent elements and swaps them until they are in the intended
        /// order.<br/>
        /// Time Complexity: Best <c>Ω(n)</c>, Average <c>Θ(n^2)</c>, Worst <c>O(n^2)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void BubbleSort<T>(T[] array)
            where T : IComparable<T>
        {
            int n = array.Length;

            // step through the array for multiple iterations until sorted
            for (int step = 0; step < n - 1; step++)
            {
                bool swapped = false;

                // loop to compare elements
                for (int j = 0; j < n - step - 1; j++)
                {
                    // if the left element is greater than the right element
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        // swap the elements so the smaller element is on the left
                        SortUtils.Swap(array, j, j + 1);
                        swapped = true;
                    }
                }

                // the array is already sorted if nothing was swapped
                if (!swapped) {
                    break;
                }
            }
        }

        /// <summary>
        /// Bucket Sort is a sorting algorithm that divides the unsorted array
        /// elements into several groups called buckets. Each bucket is then
        /// sorted using any suitable sorting algorithm. Finally, the sorted
        /// buckets are combined to form a final sorted array.<br/>
        /// Time Complexity: Best <c>Ω(n+k)</c>, Average <c>Θ(n+k)</c>, Worst <c>O(n^2)</c><br/>
        /// Space Complexity: <c>O(n)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="k">The number of buckets to create.</param>
        public static void BucketSort(float[] array, int k)
        {
            int n = array.Length;

            // no buckets to fill or empty array
            if (k <= 0 || n <= 0) {
                return;
            }

            // calculate the range of each bucket
            float max = SortUtils.Max(array, n);
            float min = SortUtils.Min(array, n);
            float range = (max - min) / k;

            // if the range is zero then the array is all the same value
            if (range == 0f) {
                return;
            }

            List<float>[] buckets = new List<float>[k];

            // create empty buckets
            for (int i = 0; i < k; i++) {
                buckets[i] = new List<float>();
            }

            // scatter the array elements into the correct bucket
            for (int i = 0; i < array.Length; i++)
            {
                float x = array[i];
                int index = (int)((x - min) / range);

                if (index < k) {
                    buckets[index].Add(x);
                } else {
                    buckets[index - 1].Add(x);
                }
            }

            // sort individual buckets
            for (int i = 0; i < k; i++)
            {
                List<float> bucket = buckets[i];

                if (bucket.Count > 0) {
                    buckets[i].Sort();
                }
            }

            int count = 0;

            // gather sorted elements to the original array
            for (int i = 0; i < k; i++)
            {
                List<float> bucket = buckets[i];

                for (int j = 0; j < bucket.Count; j++) {
                    array[count++] = bucket[j];
                }
            }
        }

        /// <summary>
        /// Bucket Sort is a sorting algorithm that divides the unsorted array
        /// elements into several groups called buckets. Each bucket is then
        /// sorted using any suitable sorting algorithm. Finally, the sorted
        /// buckets are combined to form a final sorted array.<br/>
        /// Time Complexity: Best <c>Ω(n+k)</c>, Average <c>Θ(n+k)</c>, Worst <c>O(n^2)</c><br/>
        /// Space Complexity: <c>O(n)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="k">The number of buckets to create.</param>
        public static void BucketSort(int[] array, int k)
        {
            int n = array.Length;

            // no buckets to fill or empty array
            if (k <= 0 || n <= 0) {
                return;
            }

            // calculate the range of each bucket
            int max = SortUtils.Max(array, n);
            int min = SortUtils.Min(array, n);
            float range = (float)(max - min) / k;

            // if the range is zero then the array is all the same value
            if (range == 0f) {
                return;
            }

            List<int>[] buckets = new List<int>[k];

            // create empty buckets
            for (int i = 0; i < k; i++) {
                buckets[i] = new List<int>();
            }

            // scatter the array elements into the correct bucket
            for (int i = 0; i < array.Length; i++)
            {
                int x = array[i];
                int index = (int)((x - min) / range);

                if (index < k) {
                    buckets[index].Add(x);
                } else {
                    buckets[index - 1].Add(x);
                }
            }

            // sort individual buckets
            for (int i = 0; i < k; i++)
            {
                List<int> bucket = buckets[i];

                if (bucket.Count > 0) {
                    buckets[i].Sort();
                }
            }

            int count = 0;

            // gather sorted elements to the original array
            for (int i = 0; i < k; i++)
            {
                List<int> bucket = buckets[i];

                for (int j = 0; j < bucket.Count; j++) {
                    array[count++] = bucket[j];
                }
            }
        }

        /// <summary>
        /// Counting sort is a sorting algorithm that sorts the elements of an
        /// array by counting the number of occurrences of each unique element
        /// in the array. The count is stored in an auxiliary array and the
        /// sorting is done by mapping the count as an index of the auxiliary
        /// array.<br/>
        /// Time Complexity: Best <c>Ω(n+k)</c>, Average <c>Θ(n+k)</c>, Worst <c>O(n+k)</c><br/>
        /// Space Complexity: <c>O(k)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void CountingSort(int[] array)
        {
            int n = array.Length;
            int max = SortUtils.Max(array, n);

            int[] count = new int[max + 1];

            // count each element in the array
            for (int i = 0; i < n; i++) {
                count[array[i]]++;
            }

            // calculate the cumulative count
            for (int i = 1; i <= max; i++) {
                count[i] += count[i - 1];
            }

            int[] output = new int[n];

            // place the elements in sorted order
            // iterate in reverse to maintain stability
            for (int i = n - 1; i >= 0; i--)
            {
                int x = array[i];
                output[count[x] - 1] = x;
                count[x]--;
            }

            // copy the sorted output into the original array
            SortUtils.Copy(output, array);
        }

        /// <summary>
        /// Counting sort is a sorting algorithm that sorts the elements of an
        /// array by counting the number of occurrences of each unique element
        /// in the array. The count is stored in an auxiliary array and the
        /// sorting is done by mapping the count as an index of the auxiliary
        /// array.<br/>
        /// Time Complexity: Best <c>Ω(n+k)</c>, Average <c>Θ(n+k)</c>, Worst <c>O(n+k)</c><br/>
        /// Space Complexity: <c>O(k)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="getter">A function that returns an integer property of a given array element such that it can be counted.</param>
        public static void CountingSort<T>(T[] array, Func<T, int> getter)
        {
            int n = array.Length;
            int max = SortUtils.Max(array, getter, n);

            int[] count = new int[max + 1];

            // count each element in the array
            for (int i = 0; i < n; i++) {
                count[getter(array[i])]++;
            }

            // calculate the cumulative count
            for (int i = 1; i <= max; i++) {
                count[i] += count[i - 1];
            }

            T[] output = new T[n];

            // place the elements in sorted order
            // iterate in reverse to maintain stability
            for (int i = n - 1; i >= 0; i--)
            {
                T element = array[i];
                int prop = getter(element);
                output[count[prop] - 1] = element;
                count[prop]--;
            }

            // copy the sorted output into the original array
            SortUtils.Copy(output, array);
        }

        /// <summary>
        /// Heap sort is a comparison-based sorting algorithm that works by
        /// visualizing the elements of the array as a special kind of complete
        /// binary tree called a heap. Like selection sort, heap sort divides
        /// its input into a sorted and unsorted region, and it iteratively
        /// shrinks the unsorted region by moving the largest element at the
        /// root of the tree to the sorted region.<br/>
        /// Time Complexity: Best <c>Ω(n log n)</c>, Average <c>Θ(n log n)</c>, Worst <c>O(n log n)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// Stable: No
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void HeapSort<T>(T[] array)
            where T : IComparable<T>
        {
            int n = array.Length;

            // build a max-heap tree from the bottom up
            for (int i = n / 2 - 1; i >= 0; i--) {
                Heapify(array, n, i);
            }

            // heap sort while reducing the heap size by 1 each iteration to
            // seperate the sorted elements from the tree
            for (int i = n - 1; i >= 0; i--)
            {
                // move the root element (largest element) to the vacant spot at
                // the end of the tree
                SortUtils.Swap(array, 0, i);

                // heapify the root element again so the largest element is at
                // the root
                Heapify(array, i, 0);
            }
        }

        private static void Heapify<T>(T[] array, int n, int root)
            where T : IComparable<T>
        {
            // find the largest among root, left child, and right child
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // if the left child is larger, assign as the largest
            if (left < n && array[left].CompareTo(array[largest]) > 0) {
                largest = left;
            }

            // if the right child is larger, assign as the largest
            if (right < n && array[right].CompareTo(array[largest]) > 0) {
                largest = right;
            }

            // swap and continue heapifying if the root is not the largest
            if (largest != root)
            {
                SortUtils.Swap(array, root, largest);
                Heapify(array, n, largest);
            }
        }

        /// <summary>
        /// Insertion sort is a comparison-based sorting algorithm that places
        /// an unsorted element at its suitable place in each iteration. The
        /// algorithm works similar to the way you sort playing cards in your
        /// hands. The array is virtually split into a sorted and unsorted part.
        /// Values from the unsorted part are picked and placed at the correct
        /// position in the sorted part.<br/>
        /// Time Complexity: Best <c>Ω(n)</c>, Average <c>Θ(n^2)</c>, Worst <c>O(n^2)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void InsertionSort<T>(T[] array)
            where T : IComparable<T>
        {
            int n = array.Length;

            // step through the array for multiple iterations until sorted
            for (int step = 1; step < n; step++)
            {
                T key = array[step];
                int j = step - 1;

                // while the key element is smaller than its predecessor
                // shift the elements one position up to make room for the
                // swapped key
                while (j >= 0 && key.CompareTo(array[j]) < 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        /// <summary>
        /// Merge sort is a comparison-based sorting algorithm that divides the
        /// array into two halves, sorts each half, and then merges the sorted
        /// halves back together. This process is repeated until the entire
        /// array is sorted. <br/>
        /// Time Complexity: Best <c>Ω(n log n)</c>, Average <c>Θ(n log n)</c>, Worst <c>O(n log n)</c><br/>
        /// Space Complexity: <c>O(n)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void MergeSort<T>(T[] array)
            where T : IComparable<T>
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private static void MergeSort<T>(T[] array, int left, int right)
            where T : IComparable<T>
        {
            if (left < right)
            {
                // find the mid point
                int mid = left + (right - left) / 2;

                // sort the first and second halves
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);

                // merge the sorted halves
                Merge(array, left, mid, right);
            }
        }

        private static void Merge<T>(T[] array, int left, int mid, int right)
            where T : IComparable<T>
        {
            // find the sizes of the two sub-arrays to be merged
            int n1 = mid - left + 1;
            int n2 = right - mid;

            T[] L = new T[n1]; // array[l..m]
            T[] R = new T[n2]; // array[m+1..r]

            // copy data to temp arrays
            SortUtils.Copy(array, L, left);
            SortUtils.Copy(array, R, mid + 1);

            // maintain current index of sub-arrays and main array
            int i = 0, j = 0, k = left;

            // merge the sub-arrays back into the main array by taking the
            // smaller element of the two - repeat this until hitting the
            // boundary of either sub-array
            while (i < n1 && j < n2)
            {
                // if the left element is less than the right element
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    // copy the left element to the main array
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    // copy the right element to the main array
                    array[k] = R[j];
                    j++;
                }

                k++;
            }

            // copy the remaining elements of the left array
            while (i < n1) {
                array[k++] = L[i++];
            }

            // copy the remaining elements of the right array
            while (j < n2) {
                array[k++] = R[j++];
            }
        }

        /// <summary>
        /// Radix sort is a sorting algorithm that sorts the elements by first
        /// grouping the individual digits of the same place value then sorts
        /// the elements according to their increasing/decreasing order.<br/>
        /// Time Complexity: Best <c>Ω(nk)</c>, Average <c>Θ(nk)</c>, Worst <c>O(nk)</c><br/>
        /// Space Complexity: <c>O(n+k)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void RadixSort(int[] array)
        {
            int n = array.Length;
            int max = SortUtils.Max(array, n);

            // construct these here to prevent multiple allocations
            int[] output = new int[n];
            int[] count = new int[10];

            // apply counting sort to sort elements based on place value
            for (int place = 1; max / place > 0; place *= 10) {
                RadixCountingSort(array, output, count, place, n);
            }
        }

        private static void RadixCountingSort(int[] array, int[] output, int[] count, int place, int n)
        {
            // reset arrays instead of allocating new arrays
            SortUtils.Reset(output, n);
            SortUtils.Reset(count, 10);

            // count each element in the array
            for (int i = 0; i < n; i++) {
                count[(array[i] / place) % 10]++;
            }

            // calculate the cumulative count
            for (int i = 1; i < 10; i++) {
                count[i] += count[i - 1];
            }

            // place the elements in sorted order
            // iterate in reverse to maintain stability
            for (int i = n - 1; i >= 0; i--)
            {
                int element = array[i];
                int radix = (element / place) % 10;
                output[count[radix] - 1] = element;
                count[radix]--;
            }

            // copy the sorted output into the original array
            SortUtils.Copy(output, array);
        }

        /// <summary>
        /// Radix sort is a sorting algorithm that sorts the elements by first
        /// grouping the individual digits of the same place value then sorts
        /// the elements according to their increasing/decreasing order.<br/>
        /// Time Complexity: Best <c>Ω(nk)</c>, Average <c>Θ(nk)</c>, Worst <c>O(nk)</c><br/>
        /// Space Complexity: <c>O(n+k)</c><br/>
        /// Stable: Yes
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="getter">A function that returns an integer property of a given array element such that it can be counted.</param>
        public static void RadixSort<T>(T[] array, Func<T, int> getter)
        {
            int n = array.Length;
            int max = SortUtils.Max(array, getter, n);

            // construct these here to prevent multiple allocations
            T[] output = new T[n];
            int[] count = new int[10];

            // apply counting sort to sort elements based on place value
            for (int place = 1; max / place > 0; place *= 10) {
                RadixCountingSort(array, getter, output, count, place, n);
            }
        }

        private static void RadixCountingSort<T>(T[] array, Func<T, int> getter, T[] output, int[] count, int place, int n)
        {
            // reset arrays instead of allocating new arrays
            SortUtils.Reset(output, n);
            SortUtils.Reset(count, 10);

            // count each element in the array
            for (int i = 0; i < n; i++) {
                count[(getter(array[i]) / place) % 10]++;
            }

            // calculate the cumulative count
            for (int i = 1; i < 10; i++) {
                count[i] += count[i - 1];
            }

            // place the elements in sorted order
            // iterate in reverse to maintain stability
            for (int i = n - 1; i >= 0; i--)
            {
                T element = array[i];
                int radix = (getter(element) / place) % 10;
                output[count[radix] - 1] = element;
                count[radix]--;
            }

            // copy the sorted output into the original array
            SortUtils.Copy(output, array);
        }

        /// <summary>
        /// Selection sort is a comparison-based sorting algorithm that selects
        /// the smallest element from an unsorted list in each iteration and
        /// places that element at the beginning of the unsorted list.<br/>
        /// Time Complexity: Best <c>Ω(n^2)</c>, Average <c>Θ(n^2)</c>, Worst <c>O(n^2)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// Stable: No
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void SelectionSort<T>(T[] array)
            where T : IComparable<T>
        {
            int size = array.Length;

            // step through the array for multiple iterations until sorted
            for (int step = 0; step < size - 1; step++)
            {
                int minIndex = step;

                // loop to find the smallest element
                for (int j = step + 1; j < size; j++)
                {
                    // save the index if the current element is smaller than the min
                    if (array[j].CompareTo(array[minIndex]) < 0) {
                        minIndex = j;
                    }
                }

                // move the smallest element to the front
                SortUtils.Swap(array, step, minIndex);
            }
        }

        /// <summary>
        /// Shell sort is a comparison-based sorting algorithm that generalizes
        /// the insertion sort algorithm. It first sorts elements that are far
        /// apart from each other and successively reduces the interval between
        /// the elements to be sorted.<br/>
        /// Time Complexity: Best <c>Ω(n log n)</c>, Average <c>Θ(n log n)</c>, Worst <c>O(n^2)</c><br/>
        /// Space Complexity: <c>O(1)</c><br/>
        /// Stable: No
        /// </summary>
        public static void ShellSort<T>(T[] array)
            where T : IComparable<T>
        {
            int n = array.Length;

            // start with a big gap then reduce with every iteration
            // e.g. n/2, n/4, n/8, etc
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // perform a gapped insertion sort for this gap size
                for (int i = gap; i < n; i += 1)
                {
                    T temp = array[i];
                    int j;

                    // shift earlier gap-sorted elements up until the correct
                    // location for a[i] is found
                    for (j = i; j >= gap && array[j - gap].CompareTo(temp) > 0; j -= gap) {
                        array[j] = array[j - gap];
                    }

                    array[j] = temp;
                }
            }
        }

        /// <summary>
        /// Quick sort is a comparison-based sorting algorithm based on the
        /// divide and conquer approach where an array is divided into subarrays
        /// by selecting a pivot element. Elements less than the pivot are
        /// placed on the left and elements greater than the pivot are placed on
        /// the right. This partition is done recursively until the array is
        /// sorted.<br/>
        /// Time Complexity: Best <c>Ω(n log n)</c>, Average <c>Θ(n log n)</c>, Worst <c>O(n^2)</c><br/>
        /// Space Complexity: <c>O(log n)</c><br/>
        /// Stable: No
        /// </summary>
        public static void QuickSort<T>(T[] array)
            where T : IComparable<T>
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort<T>(T[] array, int left, int right)
            where T : IComparable<T>
        {
            if (left < right)
            {
                // find the pivot index such that
                // - elements smaller than the pivot are on the left
                // - elements greater than the pivot are on the right
                int pivot = Partition(array, left, right);

                // recursive call on the left of the pivot
                QuickSort(array, left, pivot - 1);

                // recursive call on the right of the pivot
                QuickSort(array, pivot + 1, right);
            }
        }

        private static int Partition<T>(T[] array, int left, int right)
            where T : IComparable<T>
        {
            // choose the right-most element as the pivot
            T pivot = array[right];

            // index for greater element
            int i = left - 1;

            // traverse through all elements and compare to the pivot
            for (int j = left; j < right; j++)
            {
                // if the current element is smaller than the pivot
                if (array[j].CompareTo(pivot) < 0)
                {
                    // swap with the greater element indexed at i
                    SortUtils.Swap(array, ++i, j);
                }
            }

            // swap the pivot element with the greater element indexed at i
            SortUtils.Swap(array, ++i, right);

            // return the position from where the partition is done
            return i;
        }

    }

    /// <summary>
    /// Common utility functions for sorting algorithms.
    /// </summary>
    internal static class SortUtils
    {
        /// <summary>
        /// Swaps two elements in the array at the respective indexes.
        /// </summary>
        /// <param name="array">The array containing the elements.</param>
        /// <param name="i">The index of the first element to swap.</param>
        /// <param name="j">The index of the second element to swap.</param>
        public static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /// <summary>
        /// Copies the elements from a source array to a destination array.
        /// </summary>
        /// <param name="src">The source array to copy from.</param>
        /// <param name="dest">The destination array to copy to.</param>
        /// <param name="offset">The offset starting index from the source array (default=0).</param>
        public static void Copy<T>(T[] src, T[] dest, int offset = 0)
        {
            for (int i = 0; i < dest.Length; i++) {
                dest[i] = src[i + offset];
            }
        }

        /// <summary>
        /// Resets all values of an array to the default value.
        /// </summary>
        /// <param name="array">The array to reset.</param>
        public static void Reset<T>(T[] array, int n)
        {
            for (int i = 0; i < n; i++) {
                array[i] = default;
            }
        }

        /// <summary>
        /// Returns the largest element in the array.
        /// </summary>
        /// <param name="array">The array to traverse.</param>
        /// <param name="n">The length of the array.</param>
        public static int Max(int[] array, int n)
        {
            int max = array[0];

            for (int i = 1; i < n; i++)
            {
                int x = array[i];

                if (x > max) {
                    max = x;
                }
            }

            return max;
        }

        /// <summary>
        /// Returns the largest element in the array.
        /// </summary>
        /// <param name="array">The array to traverse.</param>
        /// <param name="n">The length of the array.</param>
        public static T Max<T>(T[] array, int n)
            where T : IComparable<T>
        {
            T max = array[0];

            for (int i = 1; i < n; i++)
            {
                T element = array[i];

                if (element.CompareTo(max) > 0) {
                    max = element;
                }
            }

            return max;
        }

        /// <summary>
        /// Returns the largest element in the array.
        /// </summary>
        /// <param name="array">The array to traverse.</param>
        /// <param name="getter">A function that returns an integer property of a given array element such that it can be counted.</param>
        /// <param name="n">The length of the array.</param>
        public static int Max<T>(T[] array, Func<T, int> getter, int n)
        {
            int max = getter(array[0]);

            for (int i = 1; i < n; i++)
            {
                int prop = getter(array[i]);

                if (prop > max) {
                    max = prop;
                }
            }

            return max;
        }

        /// <summary>
        /// Returns the smallest element in the array.
        /// </summary>
        /// <param name="array">The array to traverse.</param>
        /// <param name="n">The length of the array.</param>
        public static int Min(int[] array, int n)
        {
            int min = array[0];

            for (int i = 1; i < n; i++)
            {
                int x = array[i];

                if (x < min) {
                    min = x;
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the smallest element in the array.
        /// </summary>
        /// <param name="array">The array to traverse.</param>
        /// <param name="n">The length of the array.</param>
        public static T Min<T>(T[] array, int n)
            where T : IComparable<T>
        {
            T min = array[0];

            for (int i = 1; i < n; i++)
            {
                T element = array[i];

                if (element.CompareTo(min) < 0) {
                    min = element;
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the smallest element in the array.
        /// </summary>
        /// <param name="array">The array to traverse.</param>
        /// <param name="getter">A function that returns an integer property of a given array element such that it can be counted.</param>
        /// <param name="n">The length of the array.</param>
        public static int Min<T>(T[] array, Func<T, int> getter, int n)
        {
            int min = getter(array[0]);

            for (int i = 1; i < n; i++)
            {
                int prop = getter(array[i]);

                if (prop < min) {
                    min = prop;
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the number of digits in <paramref name="n"/>.
        /// </summary>
        /// <param name="n">The number to calculate the amount of digits in.</param>
        public static int Digits(int n)
        {
            int i = 1;

            if (n < 10) {
                return 1;
            }

            while (n > (int)Math.Pow(10, i)) {
                i++;
            }

            return i;
        }

    }

}
