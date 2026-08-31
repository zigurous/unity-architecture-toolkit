using System;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A type of action performed after a set game tick delay.
    /// </summary>
    public interface IDelayedTickAction : IDisposable
    {
        /// <summary>
        /// The game tick to invoke the action on.
        /// </summary>
        public int InvokeTick { get; }

        /// <summary>
        /// Performs the action.
        /// </summary>
        public void Perform();
    }

    /// <summary>
    /// An action performed after a set game tick delay.
    /// </summary>
    public struct DelayedTickAction : IDelayedTickAction
    {
        /// <summary>
        /// An internal state of a <see cref="DelayedTickAction"/>.
        /// </summary>
        internal enum State
        {
            Queued,
            Performed,
            Disposed,
        }

        /// <summary>
        /// The internal state of the action.
        /// </summary>
        internal State state;

        /// <summary>
        /// The delegate to invoke when the action is performed.
        /// </summary>
        public Action action;

        /// <summary>
        /// The game tick to invoke the action on.
        /// </summary>
        public int invokeTick;

        /// <inheritdoc/>
        public readonly int InvokeTick => invokeTick;

        /// <inheritdoc/>
        public void Perform()
        {
            action?.Invoke();
            state = State.Performed;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            action = null;
            state = State.Disposed;
        }

    }

}
