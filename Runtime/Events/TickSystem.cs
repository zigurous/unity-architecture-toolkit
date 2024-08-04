using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Invokes a tick event at a fixed interval.
    /// </summary>
    [AddComponentMenu("Zigurous/Events/Tick System")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/TickSystem")]
    public sealed class TickSystem : MonoBehaviour
    {
        internal static volatile TickSystem globalInstance;
        private static readonly object threadLock = new();
        private static bool isUnloading = false;

        private static TickSystem GetGlobalInstance()
        {
            if (globalInstance == null && !isUnloading)
            {
                lock (threadLock)
                {
                    GameObject go = new()
                    {
                        name = "GlobalTickSystem",
                        hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector,
                    };

                    if (Application.isPlaying) {
                        DontDestroyOnLoad(go);
                    }

                    globalInstance = go.AddComponent<TickSystem>();
                }
            }

            return globalInstance;
        }

        /// <summary>
        /// The global instance of the TickSystem.
        /// </summary>
        public static TickSystem Global => GetGlobalInstance();

        /// <summary>
        /// The rate at which the tick event is invoked.
        /// </summary>
        [Tooltip("The rate at which the tick event is invoked.")]
        public float tickRate = 0.6f;

        /// <summary>
        /// The event invoked at the tick rate.
        /// </summary>
        public event System.Action ticked;

        private void OnDestroy()
        {
            if (this == globalInstance) {
                globalInstance = null;
            }
        }

        private void OnApplicationQuit()
        {
            if (this == globalInstance) {
                isUnloading = true;
            }
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(Tick), tickRate, tickRate);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Tick));
        }

        private void Tick()
        {
            ticked?.Invoke();
        }

    }

}
