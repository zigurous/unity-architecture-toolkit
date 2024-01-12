using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A behavior that invokes timed events at a set interval and/or duration.
    /// </summary>
    [AddComponentMenu("Zigurous/Utility/Timed Behaviour")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/TimedBehaviour")]
    public sealed class TimedBehaviour : MonoBehaviour
    {
        /// <summary>
        /// The settings of the timer.
        /// </summary>
        [Tooltip("The settings of the timer.")]
        public TimerSettings settings = new();

        /// <summary>
        /// The events invoked by the timer.
        /// </summary>
        [Tooltip("The events invoked by the timer.")]
        public TimerEvents events = new();

        /// <summary>
        /// The current stats of the timer (Read only).
        /// </summary>
        public readonly TimerStats stats = new();

        /// <summary>
        /// Resets the elapsed time and re-enables the timer. This does not
        /// reset the tracked timer stats.
        /// </summary>
        public void Restart()
        {
            stats.ResetElapsedTime();
            enabled = true;
        }

        private void OnEnable()
        {
            if (settings.resetElapsedOnEnable) {
                stats.ResetElapsedTime();
            }

            if (settings.resetCountersOnEnable) {
                stats.ResetCounters();
            }
        }

        private void Update()
        {
            float deltaTime = settings.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

            stats.elapsedTime += deltaTime;
            stats.elapsedTimeSinceLastTick += deltaTime;
            stats.elapsedTimeSinceLastCompletion += deltaTime;

            if (settings.interval > 0f && stats.elapsedTimeSinceLastTick >= settings.interval) {
                Tick();
            }

            if (settings.duration > 0f && stats.elapsedTimeSinceLastCompletion >= settings.duration) {
                Complete();
            }
        }

        private void Tick()
        {
            stats.IncrementTick(Time.time);
            events.onTick?.Invoke();
            stats.elapsedTimeSinceLastTick -= settings.interval;
        }

        private void Complete()
        {
            stats.IncrementCompletion(Time.time);
            events.onComplete?.Invoke();
            stats.elapsedTimeSinceLastCompletion -= settings.duration;
            enabled = false;
        }

    }

}
