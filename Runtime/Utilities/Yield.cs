using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Caches yield statements to minimize garbage collection.
    /// </summary>
    public static class Yield
    {
        /// <summary>
        /// The initial capacity of the yield cache.
        /// </summary>
        public static int initialCapacity = 8;

        /// <summary>
        /// Waits until the end of the frame, just before displaying the frame
        /// on screen.
        /// </summary>
        public static readonly WaitForEndOfFrame EndOfFrame = new();

        /// <summary>
        /// Waits until the next fixed frame rate update function.
        /// </summary>
        public static readonly WaitForFixedUpdate FixedUpdate = new();

        /// <summary>
        /// Stores WaitForSeconds statements.
        /// </summary>
        private static Dictionary<int, WaitForSeconds> waitForSeconds;

        /// <summary>
        /// Stores WaitForSecondsRealtime statements.
        /// </summary>
        private static Dictionary<int, WaitForSecondsRealtime> waitForSecondsRealtime;

        /// <summary>
        /// Stores WaitUntil statements.
        /// </summary>
        private static Dictionary<int, WaitUntil> waitUntil;

        /// <summary>
        /// Stores WaitWhile statements.
        /// </summary>
        private static Dictionary<int, WaitWhile> waitWhile;

        /// <summary>
        /// Suspends the coroutine execution for the given amount of seconds
        /// using scaled time. The amount of seconds is cached as an integer in
        /// milliseconds to create more cache hits, but this results in a small
        /// precision loss in certain situations.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait.</param>
        /// <returns>The yield statement.</returns>
        public static WaitForSeconds Wait(float seconds)
        {
            waitForSeconds ??= new Dictionary<int, WaitForSeconds>(initialCapacity);

            int milliseconds = Mathf.RoundToInt(seconds * 1000f);

            if (!waitForSeconds.ContainsKey(milliseconds))
            {
                WaitForSeconds yield = new(milliseconds / 1000f);
                waitForSeconds.Add(milliseconds, yield);
                return yield;
            }

            return waitForSeconds[milliseconds];
        }

        /// <summary>
        /// Suspends the coroutine execution for the given amount of seconds
        /// using unscaled time. The amount of seconds is cached as an integer
        /// in milliseconds to create more cache hits, but this results in a
        /// small precision loss in certain situations.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait.</param>
        /// <returns>The yield statement.</returns>
        public static WaitForSecondsRealtime WaitRealtime(float seconds)
        {
            waitForSecondsRealtime ??= new Dictionary<int, WaitForSecondsRealtime>(initialCapacity);

            int milliseconds = Mathf.RoundToInt(seconds * 1000f);

            if (!waitForSecondsRealtime.ContainsKey(milliseconds))
            {
                WaitForSecondsRealtime yield = new(milliseconds / 1000f);
                waitForSecondsRealtime.Add(milliseconds, yield);
                return yield;
            }

            return waitForSecondsRealtime[milliseconds];
        }

        /// <summary>
        /// Suspends the coroutine execution until the supplied delegate
        /// evaluates to true.
        /// </summary>
        /// <param name="predicate">The delegate to evaluate.</param>
        /// <param name="id">The id to cache the yield statement with.</param>
        /// <returns>The yield statement.</returns>
        public static WaitUntil WaitUntil(System.Func<bool> predicate, int id)
        {
            waitUntil ??= new Dictionary<int, WaitUntil>(initialCapacity);

            if (!waitUntil.ContainsKey(id))
            {
                WaitUntil yield = new(predicate);
                waitUntil.Add(id, yield);
                return yield;
            }

            return waitUntil[id];
        }

        /// <summary>
        /// Suspends the coroutine execution until the supplied delegate
        /// evaluates to false.
        /// </summary>
        /// <param name="predicate">The delegate to evaluate.</param>
        /// <param name="id">The id to cache the yield statement with.</param>
        /// <returns>The yield statement.</returns>
        public static WaitWhile WaitWhile(System.Func<bool> predicate, int id)
        {
            waitWhile ??= new Dictionary<int, WaitWhile>(initialCapacity);

            if (!waitWhile.ContainsKey(id))
            {
                WaitWhile yield = new(predicate);
                waitWhile.Add(id, yield);
                return yield;
            }

            return waitWhile[id];
        }

    }

}
