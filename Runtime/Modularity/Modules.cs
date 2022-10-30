using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Manages a list of registered entity modules.
    /// </summary>
    /// <typeparam name="T">The type of entity to manage.</typeparam>
    public sealed class Modules<T> : IModular<T>
        where T : class
    {
        /// <summary>
        /// The modules registered to the entity (Read only).
        /// </summary>
        public readonly List<T> items;

        /// <summary>
        /// A callback invoked when a module is registered.
        /// </summary>
        public Action<T> registered;

        /// <summary>
        /// A callback invoked when a module is unregistered.
        /// </summary>
        public Action<T> unregistered;

        /// <summary>
        /// The amount of modules registered to the entity (Read only).
        /// </summary>
        public int count => items.Count;

        /// <summary>
        /// Returns the module at the specified index.
        /// </summary>
        /// <param name="index">The index of the module to return.</param>
        public T this[int index] => items.ItemAt(index);

        // Prevent use of default constructor.
        private Modules() {}

        /// <summary>
        /// Creates a new module collection with a set capacity.
        /// </summary>
        /// <param name="capacity">The initial capacity of the collection.</param>
        /// <param name="registered">The callback invoked when a module is registered.</param>
        /// <param name="unregistered">The callback invoked when a module is unregistered.</param>
        public Modules(int capacity, Action<T> registered = null, Action<T> unregistered = null)
        {
            this.items = new List<T>(capacity);
            this.registered = registered;
            this.unregistered = unregistered;
        }

        /// <summary>
        /// Creates a new module collection and pre-registers a list of items.
        /// </summary>
        /// <param name="items">The items to pre-register.</param>
        /// <param name="registered">A callback invoked when a module is registered.</param>
        /// <param name="unregistered">A callback invoked when a module is unregistered.</param>
        public Modules(T[] items, Action<T> registered = null, Action<T> unregistered = null)
        {
            this.items = new List<T>(items);
            this.registered = registered;
            this.unregistered = unregistered;

            if (registered != null)
            {
                for (int i = 0; i < items.Length; i++) {
                    registered.Invoke(items[i]);
                }
            }
        }

        /// <inheritdoc/>
        /// <param name="module">The module to register.</param>
        public bool Register(T module)
        {
            if (module == null || items.Contains(module)) {
                return false;
            }

            items.Add(module);

            if (registered != null) {
                registered.Invoke(module);
            }

            return true;
        }

        /// <inheritdoc/>
        /// <param name="module">The module to unregister.</param>
        public bool Unregister(T module)
        {
            if (module != null && items.Remove(module))
            {
                if (unregistered != null) {
                    unregistered.Invoke(module);
                }

                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        /// <param name="module">The module to check for registration.</param>
        public bool IsRegistered(T module)
        {
            return items.Contains(module);
        }

    }

}
