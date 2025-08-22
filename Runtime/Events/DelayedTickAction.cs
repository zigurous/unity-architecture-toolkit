using System;

namespace Zigurous.Architecture
{
    public interface IDelayedTickAction
    {
        public int InvokeTick { get; }

        public void Perform();
    }

    public struct DelayedTickAction : IDelayedTickAction, IDisposable
    {
        internal enum State
        {
            Queued,
            Performed,
            Disposed,
        }

        internal State state;
        public Action action;
        public int invokeTick;
        public readonly int InvokeTick => invokeTick;

        public void Perform()
        {
            action?.Invoke();
            state = State.Performed;
        }

        public void Dispose()
        {
            action = null;
            state = State.Disposed;
        }

    }

}
