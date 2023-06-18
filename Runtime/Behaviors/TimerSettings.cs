using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// The settings for a timer.
    /// </summary>
    [System.Serializable]
    public struct TimerSettings
    {
        /// <summary>
        /// The amount of seconds between tick intervals. A tick event is
        /// invoked every interval.
        /// </summary>
        [Tooltip("The amount of seconds between tick intervals. A tick event is invoked every interval.")]
        public float interval;

        /// <summary>
        /// The amount of seconds the timer runs for. A completion event is
        /// invoked after the duration has elapsed, and the timer is disabled.
        /// The timer can be re-enabled to run again with the same duration.
        /// </summary>
        [Tooltip("The amount of seconds the timer runs for. A completion event is invoked after the duration has elapsed, and the timer is disabled. The timer can be re-enabled to run again with the same duration.")]
        public float duration;

        /// <summary>
        /// Resets the previous amount of time elapsed when the timer is
        /// re-enabled. Leaving this off allows the timer to be paused and
        /// resumed by disabling and enabling the timer behavior.
        /// </summary>
        [Tooltip("Resets the previous amount of time elapsed when the timer is re-enabled. Leaving this off allows the timer to be paused and resumed by disabling and enabling the timer behavior.")]
        public bool resetElapsedOnEnable;

        /// <summary>
        /// Resets the timer counters when the timer is re-enabled, including
        /// the number of times ticked, the number of times completed, and the
        /// timestamps of those events.
        /// </summary>
        [Tooltip("Resets the timer counters when the timer is re-enabled, including the number of times ticked, the number of times completed, and the timestamps of those events.")]
        public bool resetCountersOnEnable;

        /// <summary>
        /// Advances the timer using unscaled time.
        /// </summary>
        [Tooltip("Advances the timer using unscaled time.")]
        public bool useUnscaledTime;
    }

}
