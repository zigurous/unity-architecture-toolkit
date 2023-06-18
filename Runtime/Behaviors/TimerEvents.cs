using UnityEngine;

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
        public EventReference onTick;

        /// <summary>
        /// An event invoked every timer completion.
        /// </summary>
        [Tooltip("An event invoked every timer completion.")]
        public EventReference onComplete;
    }

}
