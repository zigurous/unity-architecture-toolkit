using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// The running stats for a timer.
    /// </summary>
    [System.Serializable]
    public sealed class TimerStats
    {
        /// <summary>
        /// The amount of seconds elapsed since the timer was started.
        /// </summary>
        [Tooltip("The amount of seconds elapsed since the timer was started.")]
        public float elapsedTime;

        /// <summary>
        /// The amount of seconds elapsed since the last tick interval.
        /// </summary>
        [Tooltip("The amount of seconds elapsed since the last tick interval.")]
        public float elapsedTimeSinceLastTick;

        /// <summary>
        /// The amount of seconds elapsed since the last completion.
        /// </summary>
        [Tooltip("The amount of seconds elapsed since the last completion.")]
        public float elapsedTimeSinceLastCompletion;

        /// <summary>
        /// The timestamp of the last tick event.
        /// </summary>
        [Tooltip("The timestamp of the last tick event.")]
        public float timeOfLastTick;

        /// <summary>
        /// The timestamp of the last completion event.
        /// </summary>
        [Tooltip("The timestamp of the last completion event.")]
        public float timeOfLastCompletion;

        /// <summary>
        /// The number of times the timer has ticked.
        /// </summary>
        [Tooltip("The number of times the timer has ticked.")]
        public int timesTicked;

        /// <summary>
        /// The number of times the timer has completed.
        /// </summary>
        [Tooltip("The number of times the timer has completed.")]
        public int timesCompleted;

        /// <summary>
        /// Increments the number of times ticked and timestamps it.
        /// </summary>
        /// <param name="time">The time of the tick interval.</param>
        public void IncrementTick(float time)
        {
            timesTicked++;
            timeOfLastTick = time;
        }

        /// <summary>
        /// Increments the number of times completed and timestamps it.
        /// </summary>
        /// <param name="time">The time of completion.</param>
        public void IncrementCompletion(float time)
        {
            timesCompleted++;
            timeOfLastCompletion = time;
        }

        /// <summary>
        /// Resets all timer stats.
        /// </summary>
        public void Reset()
        {
            ResetElapsedTime();
            ResetCounters();
        }

        /// <summary>
        /// Resets the amount of time elapsed.
        /// </summary>
        public void ResetElapsedTime()
        {
            elapsedTime = 0f;
            elapsedTimeSinceLastTick = 0f;
            elapsedTimeSinceLastCompletion = 0f;
        }

        /// <summary>
        /// Resets the timer counters, i.e., the number of times ticked, the
        /// number of times completed, and the timestamps of those events.
        /// </summary>
        public void ResetCounters()
        {
            timeOfLastTick = 0f;
            timeOfLastCompletion = 0f;

            timesTicked = 0;
            timesCompleted = 0;
        }

    }

}
