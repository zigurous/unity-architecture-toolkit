using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Invokes the LateUpdate method on all registered <see cref="ILateUpdateable"/> targets.
    /// </summary>
    [AddComponentMenu("")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/LateUpdateManager")]
    public sealed class LateUpdateManager : PersistentSingletonBehaviour<LateUpdateManager>
    {
        private readonly List<ILateUpdateable> targets = new();

        /// <summary>
        /// Registers a target to be updated.
        /// </summary>
        /// <typeparam name="T">The type of target object.</typeparam>
        /// <param name="target">The target object to register.</param>
        public void Register<T>(T target) where T : class, ILateUpdateable
        {
            targets.Add(target);
            targets.Sort(Compare);
        }

        /// <summary>
        /// Unregisters a target from being updated.
        /// </summary>
        /// <typeparam name="T">The type of target object.</typeparam>
        /// <param name="target">The target object to unregister.</param>
        public void Unregister<T>(T target) where T : class, ILateUpdateable
        {
            targets.Remove(target);
        }

        private int Compare<T>(T a, T b) where T : class, ILateUpdateable
        {
            int orderA = (a as IUpdateableExecutionOrder)?.executionOrder ?? 0;
            int orderB = (b as IUpdateableExecutionOrder)?.executionOrder ?? 0;
            return orderA.CompareTo(orderB);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;

            foreach (ILateUpdateable target in targets) {
                target.LateUpdate(deltaTime);
            }
        }

    }

    /// <summary>
    /// A type that can be updated each frame by invoking the LateUpdate method.
    /// </summary>
    public interface ILateUpdateable
    {
        /// <summary>
        /// Updates the target object.
        /// </summary>
        /// <param name="deltaTime">The interval in seconds from the last frame to the current one.</param>
        void LateUpdate(float deltaTime);
    }

}
