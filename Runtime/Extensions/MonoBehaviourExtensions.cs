using System;
using System.Collections;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for Unity MonoBehaviors.
    /// </summary>
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Executes an action after a delay.
        /// </summary>
        /// <param name="behavior">The behavior to execute the action on.</param>
        /// <param name="delay">The delay in seconds.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>The coroutine.</returns>
        public static Coroutine Wait(this MonoBehaviour behavior, float delay, Action action)
        {
            return behavior.StartCoroutine(Wait(delay, action));
        }

        /// <summary>
        /// Executes an action after a delay.
        /// </summary>
        /// <param name="delay">The delay in seconds.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>The coroutine enumerator.</returns>
        private static IEnumerator Wait(float delay, Action action)
        {
            yield return Yield.Wait(delay);
            action();
        }

        /// <summary>
        /// Executes an action after a delay.
        /// </summary>
        /// <typeparam name="T">The type of the object to pass to the action.</typeparam>
        /// <param name="behavior">The behavior to execute the action on.</param>
        /// <param name="delay">The delay in seconds.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="obj">The object to pass to the action.</param>
        /// <returns>The coroutine.</returns>
        public static Coroutine Wait<T>(this MonoBehaviour behavior, float delay, Action<T> action, T obj)
        {
            return behavior.StartCoroutine(Wait(delay, action, obj));
        }

        /// <summary>
        /// Executes an action after a delay.
        /// </summary>
        /// <typeparam name="T">The type of the object to pass to the action.</typeparam>
        /// <param name="delay">The delay in seconds.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="obj">The object to pass to the action.</param>
        /// <returns>The coroutine enumerator.</returns>
        private static IEnumerator Wait<T>(float delay, Action<T> action, T obj)
        {
            yield return Yield.Wait(delay);
            action(obj);
        }

        /// <summary>
        /// Repeats an action at a set interval.
        /// </summary>
        /// <param name="behavior">The behavior to execute the action on.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval to repeat the action, in seconds.</param>
        /// <returns>The coroutine.</returns>
        public static Coroutine Repeat(this MonoBehaviour behavior, Action action, float interval)
        {
            return behavior.StartCoroutine(Repeat(action, interval));
        }

        /// <summary>
        /// Repeats an action at a set interval.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval to repeat the action, in seconds.</param>
        /// <returns>The coroutine enumerator.</returns>
        private static IEnumerator Repeat(Action action, float interval)
        {
            while (true)
            {
                yield return Yield.Wait(interval);
                action();
            }
        }

        /// <summary>
        /// Repeats an action at a set interval while a condition is true.
        /// </summary>
        /// <param name="behavior">The behavior to execute the action on.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval to repeat the action, in seconds.</param>
        /// <returns>The coroutine.</returns>
        public static Coroutine RepeatWhile(this MonoBehaviour behavior, Func<bool> condition, Action action, float interval)
        {
            return behavior.StartCoroutine(RepeatWhile(condition, action, interval));
        }

        /// <summary>
        /// Repeats an action at a set interval while a condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval to repeat the action, in seconds.</param>
        /// <returns>The coroutine enumerator.</returns>
        private static IEnumerator RepeatWhile(Func<bool> condition, Action action, float interval)
        {
            while (condition())
            {
                yield return Yield.Wait(interval);
                action();
            }
        }

        /// <summary>
        /// Repeats an action at a set interval until a condition is met.
        /// </summary>
        /// <param name="behavior">The behavior to execute the action on.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval to repeat the action, in seconds.</param>
        /// <returns>The coroutine.</returns>
        public static Coroutine RepeatUntil(this MonoBehaviour behavior, Func<bool> condition, Action action, float interval)
        {
            return behavior.StartCoroutine(RepeatUntil(condition, action, interval));
        }

        /// <summary>
        /// Repeats an action at a set interval until a condition is met.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval to repeat the action, in seconds.</param>
        /// <returns>The coroutine enumerator.</returns>
        private static IEnumerator RepeatUntil(Func<bool> condition, Action action, float interval)
        {
            while (!condition())
            {
                yield return Yield.Wait(interval);
                action();
            }
        }

    }

}
