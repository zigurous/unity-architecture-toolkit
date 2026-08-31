using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A queue of actions performed after set game ticks.
    /// </summary>
    public sealed class DelayedTickActionQueue
    {
        private readonly List<DelayedTickAction> queue = new();

        /// <summary>
        /// Queues an action to be performed.
        /// </summary>
        /// <param name="action">The action to queue.</param>
        public void Enqueue(DelayedTickAction action)
        {
            action.state = DelayedTickAction.State.Queued;
            queue.Add(action);
        }

        /// <summary>
        /// Queues an action to be performed on the given game tick.
        /// </summary>
        /// <param name="action">The action to queue.</param>
        /// <param name="invokeTick">The game tick to perform the action on.</param>
        public void Enqueue(System.Action action, int invokeTick)
        {
            queue.Add(new DelayedTickAction() {
                state = DelayedTickAction.State.Queued,
                action = action,
                invokeTick = invokeTick,
            });
        }

        /// <summary>
        /// Queues an action to be performed.
        /// </summary>
        /// <typeparam name="T">The type of action.</typeparam>
        /// <param name="action">The action to queue.</param>
        public void Enqueue<T>(T action) where T : IDelayedTickAction
        {
            queue.Add(new DelayedTickAction() {
                state = DelayedTickAction.State.Queued,
                action = action.Perform,
                invokeTick = action.InvokeTick,
            });
        }

        /// <summary>
        /// Handles the current game tick and invokes any actions queued for
        /// that game tick.
        /// </summary>
        /// <param name="tick">The current game tick.</param>
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

        /// <summary>
        /// Clears any queued actions.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < queue.Count; i++) {
                queue[i].Dispose();
            }

            queue.Clear();
        }

    }

}
