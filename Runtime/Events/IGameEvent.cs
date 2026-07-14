namespace Zigurous.Architecture
{
    /// <summary>
    /// A type of game event.
    /// </summary>
    public interface IGameEvent {}

    /// <summary>
    /// A type that listens for the specified game event.
    /// </summary>
    /// <typeparam name="T">The type of event to listen to.</typeparam>
    public interface IGameEventListener<T> where T : IGameEvent
    {
        /// <summary>
        /// Handles the incoming game event <paramref name="e"/>.
        /// </summary>
        /// <param name="e">The event payload.</param>
        void OnGameEvent(T e);
    }

}
