using UnityEngine;
using UnityEngine.Events;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Listens for a custom game event to be raised and invokes a Unity event
    /// in response.
    /// </summary>
    [AddComponentMenu("Zigurous/Events/Game Event Listener")]
    public class GameEventListener : MonoBehaviour
    {
        /// <summary>
        /// The game event to listen to.
        /// </summary>
        [Tooltip("The game event to listen to.")]
        public GameEvent Event;

        /// <summary>
        /// The Unity event invoked in response to the event being raised.
        /// </summary>
        [Tooltip("The unity event invoked in response to the event being raised.")]
        public UnityEvent Response;

        /// <summary>
        /// A Unity lifecycle method called when the behavior is enabled.
        /// </summary>
        protected virtual void OnEnable()
        {
            if (Event != null) {
                Event.RegisterListener(this);
            }
        }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            if (Event != null) {
                Event.UnregisterListener(this);
            }
        }

        /// <summary>
        /// A callback invoked when the event is raised.
        /// </summary>
        public virtual void OnEventRaised()
        {
            if (Response != null) {
                Response.Invoke();
            }
        }

    }

}
