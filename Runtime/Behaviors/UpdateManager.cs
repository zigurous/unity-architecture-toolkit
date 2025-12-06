using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Invokes the Update method on all registered <see cref="IUpdateable"/> targets.
    /// </summary>
    [AddComponentMenu("")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/UpdateManager")]
    public sealed class UpdateManager : PersistentSingletonBehaviour<UpdateManager>
    {
        private readonly List<IUpdateable> targets = new();

        /// <summary>
        /// Registers a target to be updated.
        /// </summary>
        /// <typeparam name="T">The type of target object.</typeparam>
        /// <param name="target">The target object to register.</param>
        public void Register<T>(T target) where T : class, IUpdateable
        {
            if (!IsRegistered(target))
            {
                targets.Add(target);
                targets.Sort(Compare);
            }
        }

        /// <summary>
        /// Unregisters a target from being updated.
        /// </summary>
        /// <typeparam name="T">The type of target object.</typeparam>
        /// <param name="target">The target object to unregister.</param>
        public void Unregister<T>(T target) where T : class, IUpdateable
        {
            targets.Remove(target);
        }

        /// <summary>
        /// Checks if the target is registered to be updated.
        /// </summary>
        /// <typeparam name="T">The type of target object.</typeparam>
        /// <param name="target">The target object to check.</param>
        /// <returns>True if the target is registered, false otherwise.</returns>
        public bool IsRegistered<T>(T target) where T : class, IUpdateable
        {
            return targets.Contains(target);
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            for (int i = 0; i < targets.Count; i++) {
                targets[i].Update(deltaTime);
            }
        }

        private void OnDestroy()
        {
            targets.Clear();
        }

        private static int Compare<T>(T a, T b) where T : class, IUpdateable
        {
            int orderA = (a as IUpdateableExecutionOrder)?.executionOrder ?? 0;
            int orderB = (b as IUpdateableExecutionOrder)?.executionOrder ?? 0;
            return orderA.CompareTo(orderB);
        }

    }

    /// <summary>
    /// A type that can be updated each frame by invoking the Update method.
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// Updates the target object.
        /// </summary>
        /// <param name="deltaTime">The amount of seconds elapsed since the last update.</param>
        void Update(float deltaTime);
    }

    /// <summary>
    /// A type that can specify an execution order for updateable objects.
    /// </summary>
    public interface IUpdateableExecutionOrder
    {
        /// <summary>
        /// The order in which the object should be updated. Lower values are
        /// updated first.
        /// </summary>
        int executionOrder { get; }
    }

}
