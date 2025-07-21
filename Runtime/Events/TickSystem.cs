using System.Collections;
using System.Collections.Generic;
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
        /// The current tick count.
        /// </summary>
        public int count => ticks;

        /// <summary>
        /// The amount of seconds since the last tick.
        /// </summary>
        public float deltaTime => Time.time - timeOfLastTick;

        /// <summary>
        /// The event invoked at the tick rate.
        /// </summary>
        public event System.Action<int> tick;

        private List<TickDelayedAction> delayedActions;

        private void OnEnable()
        {
            timeOfLastTick = Time.time;
        }

        private void Update()
        {
            if (deltaTime >= tickRate) {
                Tick();
            }
        }

        /// <summary>
        /// Invokes a tick manually.
        /// </summary>
        public void Tick()
        {
            ticks++;
            tick?.Invoke(ticks);

            if (delayedActions != null)
            {
                for (int i = delayedActions.Count - 1; i >= 0; i--)
                {
                    if (ticks >= delayedActions[i].invokeTick)
                    {
                        delayedActions[i].action.Invoke();
                        delayedActions.RemoveAt(i);
                    }
                }
            }

            timeOfLastTick = Time.time;
        }

        /// <summary>
        /// Resets the tick count to zero and clears any delayed actions.
        /// </summary>
        public void Reset()
        {
            ticks = 0;
            delayedActions?.Clear();
            StopAllCoroutines();
        }

        /// <summary>
        /// Delays an action for a specified amount of game ticks.
        /// </summary>
        /// <param name="ticks">The amount of game ticks to wait.</param>
        /// <param name="onComplete">The action to invoke after the delay.</param>
        public void DelayAction(int ticks, System.Action onComplete)
        {
            delayedActions ??= new List<TickDelayedAction>();
            delayedActions.Add(new TickDelayedAction() {
                action = onComplete,
                invokeTick = count + ticks,
            });
        }

        /// <summary>
        /// An enumerator to yield for the specified amount of game ticks.
        /// </summary>
        /// <param name="ticks">The amount of game ticks to yield.</param>
        /// <returns>The current enumerator.</returns>
        public IEnumerator WaitForGameTicks(int ticks)
        {
            while (ticks > 0)
            {
                yield return WaitForGameTick();
                ticks--;
            }
        }

        /// <summary>
        /// An enumerator to yield for a single game tick.
        /// </summary>
        /// <returns>The current enumerator.</returns>
        public IEnumerator WaitForGameTick()
        {
            int startTick = count;

            while (count - startTick <= 0) {
                yield return null;
            }
        }

    }

}
