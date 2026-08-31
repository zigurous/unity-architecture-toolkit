namespace Zigurous.Architecture
{
    /// <summary>
    /// A type that listens for game events.
    /// </summary>
    public interface IGameEventListener {}

    /// <summary>
    /// A type that listens for the specified game event.
    /// </summary>
    /// <typeparam name="T">The type of event to listen to.</typeparam>
    public interface IGameEventListener<T> : IGameEventListener
        where T : IGameEvent
    {
        /// <summary>
        /// Handles the incoming game event <paramref name="e"/>.
        /// </summary>
        /// <param name="e">The event payload.</param>
        void OnGameEvent(T e);
    }

}
