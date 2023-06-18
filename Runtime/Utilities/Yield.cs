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
        public static readonly WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();

        /// <summary>
        /// Waits until the next fixed frame rate update function.
        /// </summary>
        public static readonly WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();

        /// <summary>
        /// Stores WaitForSeconds statements.
        /// </summary>
        private static Dictionary<float, WaitForSeconds> waitForSeconds;

        /// <summary>
        /// Stores WaitForSecondsRealtime statements.
        /// </summary>
        private static Dictionary<float, WaitForSecondsRealtime> waitForSecondsRealtime;

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
        /// using scaled time.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait.</param>
        /// <returns>The yield statement.</returns>
        public static WaitForSeconds Wait(float seconds)
        {
            if (waitForSeconds == null)
            {
                waitForSeconds = new Dictionary<float, WaitForSeconds>(
                    initialCapacity, new FloatEqualityComparer());
            }

            if (!waitForSeconds.ContainsKey(seconds))
            {
                WaitForSeconds yield = new WaitForSeconds(seconds);
                waitForSeconds.Add(seconds, yield);
                return yield;
            }

            return waitForSeconds[seconds];
        }

        /// <summary>
        /// Suspends the coroutine execution for the given amount of seconds
        /// using unscaled time.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait.</param>
        /// <returns>The yield statement.</returns>
        public static WaitForSecondsRealtime WaitRealtime(float seconds)
        {
            if (waitForSecondsRealtime == null)
            {
                waitForSecondsRealtime = new Dictionary<float, WaitForSecondsRealtime>(
                    initialCapacity, new FloatEqualityComparer());
            }

            if (!waitForSecondsRealtime.ContainsKey(seconds))
            {
                WaitForSecondsRealtime yield = new WaitForSecondsRealtime(seconds);
                waitForSecondsRealtime.Add(seconds, yield);
                return yield;
            }

            return waitForSecondsRealtime[seconds];
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
            if (waitUntil == null) {
                waitUntil = new Dictionary<int, WaitUntil>(initialCapacity);
            }

            if (!waitUntil.ContainsKey(id))
            {
                WaitUntil yield = new WaitUntil(predicate);
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
            if (waitWhile == null) {
                waitWhile = new Dictionary<int, WaitWhile>(initialCapacity);
            }

            if (!waitWhile.ContainsKey(id))
            {
                WaitWhile yield = new WaitWhile(predicate);
                waitWhile.Add(id, yield);
                return yield;
            }

            return waitWhile[id];
        }

    }

}
