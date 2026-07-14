using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A global event bus for the specified game event.
    /// </summary>
    /// <typeparam name="T">The type of event sent through the bus.</typeparam>
    public static class GameEventBus<T> where T : IGameEvent
    {
        private static List<IGameEventListener<T>> listeners;

        /// <summary>
        /// Subscribes a listener to the event.
        /// </summary>
        /// <typeparam name="L">The type of event listener.</typeparam>
        /// <param name="listener">The listener subscribing to the event.</param>
        public static void Register<L>(L listener) where L : IGameEventListener<T>
        {
            listeners ??= new();
            listeners.Add(listener);
        }

        /// <summary>
        /// Unsubscribes a listener from the event.
        /// </summary>
        /// <typeparam name="L">The type of event listener.</typeparam>
        /// <param name="listener">The listener unsubscribing from the event.</param>
        public static void Unregister<L>(L listener) where L : IGameEventListener<T>
        {
            listeners?.Remove(listener);
        }

        /// <summary>
        /// Raises the game event to be handled by the listeners.
        /// </summary>
        /// <param name="e">The event payload.</param>
        public static void Raise(T e)
        {
            if (listeners == null) return;

            for (int i = listeners.Count - 1; i >= 0; i--) {
                listeners[i].OnGameEvent(e);
            }
        }

    }

}
