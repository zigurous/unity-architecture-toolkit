using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Invokes a global tick event at a fixed interval.
    /// </summary>
    [AddComponentMenu("Zigurous/Events/Global Tick System")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/GlobalTickSystem")]
    public sealed class GlobalTickSystem : TickSystem
    {
        internal static volatile GlobalTickSystem instance;
        private static readonly object threadLock = new();
        private static bool isUnloading = false;

        private static GlobalTickSystem GetInstance()
        {
            if (instance == null)
            {
                lock (threadLock)
                {
                    instance = FindObjectOfType<GlobalTickSystem>();

                    if (instance == null && Application.isPlaying && !isUnloading)
                    {
                        GameObject singleton = new()
                        {
                            name = "GlobalTickSystem",
                            hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector
                        };

                        return singleton.AddComponent<GlobalTickSystem>();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// The global tick system instance.
        /// The instance will be created if it does not already exist.
        /// </summary>
        /// <returns>The global tick system instance.</returns>
        public static GlobalTickSystem Instance => GetInstance();

        /// <summary>
        /// Checks if the global tick system has been initialized and is
        /// available to use.
        /// </summary>
        /// <returns>True if the global tick system is available, false otherwise.</returns>
        public static bool HasInstance => instance != null;

        private void Awake()
        {
            if (instance == null || instance == this)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnApplicationQuit()
        {
            isUnloading = true;
        }

    }

}
