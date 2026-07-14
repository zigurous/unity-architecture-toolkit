using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A custom game event that inherits from ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Events/Game Event")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/GameEvent")]
    public class ScriptableGameEvent : ScriptableObject, IGameEvent
    {
        /// <summary>
        /// Raises the game event to be handled by the listeners.
        /// </summary>
        public void Raise()
        {
            GameEventBus<ScriptableGameEvent>.Raise(this);
        }

        /// <summary>
        /// Subscribes a listener to the event.
        /// </summary>
        /// <typeparam name="T">The type of event listener.</typeparam>
        /// <param name="listener">The listener subscribing to the event.</param>
        public void Register<T>(T listener) where T : IGameEventListener<ScriptableGameEvent>
        {
            GameEventBus<ScriptableGameEvent>.Register(listener);
        }

        /// <summary>
        /// Unsubscribes a listener from the event.
        /// </summary>
        /// <typeparam name="T">The type of event listener.</typeparam>
        /// <param name="listener">The listener unsubscribing from the event.</param>
        public void Unregister<T>(T listener) where T : IGameEventListener<ScriptableGameEvent>
        {
            GameEventBus<ScriptableGameEvent>.Unregister(listener);
        }

    }

}
