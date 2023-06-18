namespace Zigurous.Architecture
{
    /// <summary>
    /// A singleton that ensures only a single instance of a specified type is
    /// instantiated.
    /// </summary>
    /// <typeparam name="T">The type of object to instantiate.</typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        internal static volatile T instance;
        private static object threadLock = new object();

        private static T GetInstance()
        {
            if (instance == null)
            {
                lock (threadLock)
                {
                    if (instance == null) {
                        instance = new T();
                    }

                    return instance;
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
    }

}
