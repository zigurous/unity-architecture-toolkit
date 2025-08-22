using System.Collections.Generic;

namespace Zigurous.Architecture
{
    public sealed class DelayedTickActionQueue
    {
        private readonly List<DelayedTickAction> queue = new();

        public void Enqueue(DelayedTickAction action)
        {
            action.state = DelayedTickAction.State.Queued;
            queue.Add(action);
        }

        public void Enqueue(System.Action action, int invokeTick)
        {
            queue.Add(new DelayedTickAction() {
                state = DelayedTickAction.State.Queued,
                action = action,
                invokeTick = invokeTick,
            });
        }

        public void Enqueue<T>(T action) where T : IDelayedTickAction
        {
            queue.Add(new DelayedTickAction() {
                state = DelayedTickAction.State.Queued,
                action = action.Perform,
                invokeTick = action.InvokeTick,
            });
        }

        public void Tick(int tick)
        {
            int count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                if (queue[i].state == DelayedTickAction.State.Queued && tick >= queue[i].InvokeTick)
                {
                    DelayedTickAction action = queue[i];
                    action.Perform();
                    queue[i] = action;
                }
            }

            for (int i = queue.Count - 1; i >= 0; i--)
            {
                if (queue[i].state == DelayedTickAction.State.Performed)
                {
                    queue[i].Dispose();
                    queue.RemoveAt(i);
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < queue.Count; i++) {
                queue[i].Dispose();
            }

            queue.Clear();
        }

    }

}
