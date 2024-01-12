using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A queue of processes that are executed one at a time.
    /// </summary>
    public static class ProcessQueue<T> where T : IQueueableProcess
    {
        private static Queue<T> queue;
        private static Coroutine processor;

        /// <summary>
        /// Pauses the processing of the queue.
        /// </summary>
        public static bool paused = false;

        /// <summary>
        /// The number of processes in the queue.
        /// </summary>
        public static int Count => queue.Count;

        /// <summary>
        /// Queues a process to be executed.
        /// </summary>
        public static void Queue(T process)
        {
            queue ??= new Queue<T>();
            queue.Enqueue(process);
            processor ??= ProcessQueueHandler.Instance.StartCoroutine(Process());
        }

        /// <summary>
        /// Clears the queue of all processes.
        /// </summary>
        public static void Clear()
        {
            queue?.Clear();

            if (processor != null)
            {
                if (ProcessQueueHandler.HasInstance) {
                    ProcessQueueHandler.Instance.StopCoroutine(processor);
                }

                processor = null;
            }
        }

        private static IEnumerator Process()
        {
            yield return null;

            while (queue.Count > 0)
            {
                while (paused) {
                    yield return null;
                }

                yield return queue.Dequeue().Process();
            }

            processor = null;
        }

    }

    /// <summary>
    /// A process that can be queued and processed by a <see cref="ProcessQueue"/>.
    /// </summary>
    public interface IQueueableProcess
    {
        /// <summary>
        /// Executes processing logic.
        /// </summary>
        IEnumerator Process();
    }

    internal class ProcessQueueHandler : PersistentSingletonBehaviour<ProcessQueueHandler>
    {
    }

}
