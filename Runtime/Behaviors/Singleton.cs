using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A singleton behavior that ensures only a single instance of a specified
    /// type is instantiated in the scene. The singleton will be destroyed when
    /// the scene is unloaded.
    /// </summary>
    /// <typeparam name="T">The type of component to instantiate.</typeparam>
    public abstract class Singleton<T> : MonoBehaviour
        where T : Component
    {
        internal static volatile T instance;
        private static object threadLock = new object();
        private static bool isUnloading = false;

        private static T GetInstance()
        {
            if (instance == null)
            {
                lock (threadLock)
                {
                    instance = FindObjectOfType<T>();

                    if (instance == null && !isUnloading)
                    {
                        GameObject singleton = new GameObject();
                        singleton.name = typeof(T).Name;
                        singleton.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
                        return singleton.AddComponent<T>();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// The current instance of the class.
        /// The instance will be created if it does not already exist.
        /// </summary>
        /// <returns>The instance of the class.</returns>
        public static T Instance => GetInstance();

        /// <summary>
        /// Checks if the singleton has been initialized and an instance is
        /// available to use.
        /// </summary>
        /// <returns>True if an instance is available, false otherwise.</returns>
        public static bool HasInstance => instance != null;

        /// <summary>
        /// A Unity lifecycle method called when the behavior is initialized.
        /// </summary>
        internal virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                SetUp();
            }
            else
            {
                Destroy(this);
            }
        }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is destroyed.
        /// </summary>
        internal virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
                TearDown();
            }
        }

        /// <summary>
        /// A Unity lifecycle method called when the application is exited.
        /// </summary>
        internal virtual void OnApplicationQuit()
        {
            isUnloading = true;
            instance = null;

            Destroy(gameObject);
        }

        /// <summary>
        /// Handles initializing the singleton on Awake. This function should be
        /// used in replacement of Awake.
        /// </summary>
        protected virtual void SetUp() {}

        /// <summary>
        /// Handles deinitializing the singleton. This function should be used
        /// in replacement of OnDestroy.
        /// </summary>
        protected virtual void TearDown() {}

    }

}
