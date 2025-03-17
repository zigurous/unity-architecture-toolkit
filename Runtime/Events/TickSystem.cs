using System.Collections;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Invokes a tick event at a fixed interval.
    /// </summary>
    [AddComponentMenu("Zigurous/Events/Tick System")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/TickSystem")]
    public class TickSystem : MonoBehaviour
    {
        /// <summary>
        /// The default rate in seconds at which the tick system updates.
        /// </summary>
        public static readonly float DefaultTickRate = 0.6f; // seconds

        /// <summary>
        /// The rate in seconds at which the tick system updates.
        /// </summary>
        [Tooltip("The rate in seconds at which the tick system updates.")]
        public float tickRate = DefaultTickRate;

        [HideInInspector]
        private float timeOfLastTick;

        [ReadOnly]
        [SerializeField]
        private int ticks;

        /// <summary>
        /// The current tick number.
        /// </summary>
        public int currentTick => ticks;

        /// <summary>
        /// The amount of seconds since the last tick.
        /// </summary>
        public float deltaTime => Time.time - timeOfLastTick;

        /// <summary>
        /// The event invoked at the tick rate.
        /// </summary>
        public event System.Action tick;

        private void OnEnable()
        {
            timeOfLastTick = Time.time;
        }

        private void Update()
        {
            if (deltaTime >= tickRate)
            {
                ticks++;
                tick?.Invoke();
                timeOfLastTick = Time.time;
            }
        }

        public void ResetCount()
        {
            ticks = 0;
        }

        /// <summary>
        /// Delays an action for a specified amount of game ticks.
        /// </summary>
        /// <param name="ticks">The amount of game ticks to wait.</param>
        /// <param name="onComplete">The action to invoke after the delay.</param>
        /// <returns>The coroutine for the delayed action.</returns>
        public Coroutine DelayAction(int ticks, System.Action onComplete)
        {
            return StartCoroutine(Delay(ticks, onComplete));
        }

        private IEnumerator Delay(int ticks, System.Action onComplete)
        {
            int startTick = currentTick;

            while (ticks > 0)
            {
                while (currentTick - startTick <= 0) {
                    yield return null;
                }

                ticks--;
                startTick = currentTick;
            }

            onComplete.Invoke();
        }

    }

}
