using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Invokes a tick event at a fixed interval.
    /// </summary>
    [AddComponentMenu("Zigurous/Events/Tick System")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/TickSystem")]
    public sealed class TickSystem : PersistentSingletonBehaviour<TickSystem>
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
        private float timeSinceLastTick;

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
        public float deltaTime => Time.time - timeSinceLastTick;

        /// <summary>
        /// The event invoked at the tick rate.
        /// </summary>
        public event System.Action tick;

        private void OnEnable()
        {
            timeSinceLastTick = Time.time;
        }

        private void Update()
        {
            if (deltaTime >= tickRate)
            {
                ticks++;
                tick?.Invoke();
                timeSinceLastTick = Time.time;
            }
        }

        public void ResetCount()
        {
            ticks = 0;
        }

    }

}
