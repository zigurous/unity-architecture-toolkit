using UnityEngine;
using UnityEngine.Events;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Listens for a custom game event to be raised and invokes a Unity event
    /// in response.
    /// </summary>
    [AddComponentMenu("Zigurous/Events/Game Event Listener")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/GameEventListener")]
    public class GameEventListener : MonoBehaviour, IGameEventListener<ScriptableGameEvent>
    {
        [SerializeField]
        [Tooltip("The game event to listen to.")]
        private ScriptableGameEvent m_Event;

        [SerializeField]
        [Tooltip("The unity event invoked in response to the event being raised.")]
        private UnityEvent<ScriptableGameEvent> m_Response;

        /// <summary>
        /// The game event to listen to.
        /// </summary>
        public ScriptableGameEvent Event
        {
            get => m_Event;
            set => m_Event = value;
        }

        /// <summary>
        /// The Unity event invoked in response to the event being raised.
        /// </summary>
        public UnityEvent<ScriptableGameEvent> Response
        {
            get => m_Response;
            set => m_Response = value;
        }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is enabled.
        /// </summary>
        protected virtual void OnEnable()
        {
            GameEventBus<ScriptableGameEvent>.Listen(this);
        }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            GameEventBus<ScriptableGameEvent>.Unlisten(this);
        }

        /// <summary>
        /// A callback invoked when the event is raised.
        /// </summary>
        protected virtual void OnEventRaised(ScriptableGameEvent e)
        {
            m_Response?.Invoke(e);
        }

        /// <summary>
        /// Handles the incoming game event <paramref name="e"/>.
        /// </summary>
        /// <param name="e">The event payload.</param>
        public void OnGameEvent(ScriptableGameEvent e)
        {
            if (e == m_Event) {
                OnEventRaised(e);
            }
        }

    }

}
