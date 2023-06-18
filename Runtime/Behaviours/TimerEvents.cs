using UnityEngine;
using UnityEngine.Events;

namespace Zigurous.Architecture
{
    /// <summary>
    /// The events invoked for a timer.
    /// </summary>
    [System.Serializable]
    public sealed class TimerEvents
    {
        /// <summary>
        /// An event invoked every timer interval.
        /// </summary>
        [Tooltip("An event invoked every timer interval.")]
        public UnityEvent onTick;

        /// <summary>
        /// An event invoked every timer completion.
        /// </summary>
        [Tooltip("An event invoked every timer completion.")]
        public UnityEvent onComplete;
    }

}
