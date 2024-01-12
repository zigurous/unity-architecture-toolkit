using UnityEngine;
using UnityEngine.Events;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a UnityEvent or a GameEvent.
    /// </summary>
    [System.Serializable]
    public sealed class EventReference
    {
        /// <summary>
        /// Uses a UnityEvent instead of a GameEvent.
        /// </summary>
        [Tooltip("Uses a UnityEvent instead of a GameEvent.")]
        public bool useUnityEvent = true;

        /// <summary>
        /// The UnityEvent to use.
        /// </summary>
        [Tooltip("The UnityEvent to use.")]
        public UnityEvent unityEvent;

        /// <summary>
        /// The GameEvent to use.
        /// </summary>
        [Tooltip("The GameEvent to use.")]
        public GameEvent gameEvent;

        /// <summary>
        /// Creates a new event reference.
        /// </summary>
        public EventReference() {}

        /// <summary>
        /// Creates a new event reference to the UnityEvent.
        /// </summary>
        /// <param name="unityEvent">The UnityEvent to use.</param>
        public EventReference(UnityEvent unityEvent)
        {
            this.useUnityEvent = true;
            this.unityEvent = unityEvent;
        }

        /// <summary>
        /// Creates a new event reference to the GameEvent.
        /// </summary>
        /// <param name="gameEvent">The GameEvent to use.</param>
        public EventReference(GameEvent gameEvent)
        {
            this.useUnityEvent = false;
            this.gameEvent = gameEvent;
        }

        /// <summary>
        /// Invokes or raises the event depending on the type.
        /// </summary>
        public void Invoke()
        {
            if (useUnityEvent) {
                unityEvent?.Invoke();
            } else if (gameEvent != null) {
                gameEvent.Raise();
            }
        }

    }

}
