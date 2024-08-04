using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Invokes the FixedUpdate method on all registered <see cref="IFixedUpdateable"/> targets.
    /// </summary>
    [AddComponentMenu("")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/FixedUpdateManager")]
    public sealed class FixedUpdateManager : PersistentSingletonBehaviour<FixedUpdateManager>
    {
        private readonly List<IFixedUpdateable> targets = new();

        /// <summary>
        /// Registers a target to be updated.
        /// </summary>
        /// <typeparam name="T">The type of target object.</typeparam>
        /// <param name="target">The target object to register.</param>
        public void Register<T>(T target) where T : class, IFixedUpdateable
        {
            targets.Add(target);
            targets.Sort(Compare);
        }

        /// <summary>
        /// Unregisters a target from being updated.
        /// </summary>
        /// <typeparam name="T">The type of target object.</typeparam>
        /// <param name="target">The target object to unregister.</param>
        public void Unregister<T>(T target) where T : class, IFixedUpdateable
        {
            targets.Remove(target);
        }

        private int Compare<T>(T a, T b) where T : class, IFixedUpdateable
        {
            int orderA = (a as IUpdateableExecutionOrder)?.executionOrder ?? 0;
            int orderB = (b as IUpdateableExecutionOrder)?.executionOrder ?? 0;
            return orderA.CompareTo(orderB);
        }

        private void FixedUpdate()
        {
            float deltaTime = Time.fixedDeltaTime;

            foreach (IFixedUpdateable target in targets) {
                target.FixedUpdate(deltaTime);
            }
        }

    }

    /// <summary>
    /// A type that can be updated each frame by invoking the FixedUpdate method.
    /// </summary>
    public interface IFixedUpdateable
    {
        /// <summary>
        /// Updates the target object.
        /// </summary>
        /// <param name="deltaTime">The interval in seconds of in-game time at which physics and other fixed frame rate updates are performed.</param>
        void FixedUpdate(float deltaTime);
    }

}
