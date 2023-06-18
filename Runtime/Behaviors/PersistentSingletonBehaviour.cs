using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A singleton behavior that ensures only a single instance of a specified
    /// type is instantiated in the scene. The singleton will not be destroyed
    /// when changing scenes, thus making it persistent.
    /// </summary>
    /// <typeparam name="T">The type of component to instantiate.</typeparam>
    public abstract class PersistentSingletonBehaviour<T> : SingletonBehaviour<T>
        where T : Component
    {
        /// <inheritdoc/>
        protected override void SetUp()
        {
            if (Application.isPlaying) {
                DontDestroyOnLoad(this);
            }
        }

    }

}
