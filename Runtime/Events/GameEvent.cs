using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A custom game event that can be saved as a project asset and referenced
    /// throughout the application.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Events/Game Event")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of event listeners to invoke when the event is raised.
        /// </summary>
        private readonly List<GameEventListener> listeners = new List<GameEventListener>();

        /// <summary>
        /// Raises the game event and invokes all of the registered listeners.
        /// </summary>
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--) {
                listeners[i].OnEventRaised();
            }
        }

        /// <summary>
        /// Adds the event listener to the list of listeners that are invoked
        /// when the event is raised.
        /// </summary>
        /// <param name="listener">The event listener to register.</param>
        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener)) {
                listeners.Add(listener);
            }
        }

        /// <summary>
        /// Removes the event listener from the list of listeners that are
        /// invoked when the event is raised.
        /// </summary>
        /// <param name="listener">The event listener to unregister.</param>
        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener)) {
                listeners.Remove(listener);
            }
        }

    }

}
