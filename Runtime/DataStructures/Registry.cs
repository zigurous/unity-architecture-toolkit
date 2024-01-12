using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Manages a list of unique items and invokes callbacks when an item is
    /// added or removed from the list.
    /// </summary>
    /// <typeparam name="T">The type of item to register.</typeparam>
    public class Registry<T>
    {
        /// <summary>
        /// The items registered in the list (Read only).
        /// </summary>
        public readonly List<T> items;

        /// <summary>
        /// A callback invoked when an item is registered.
        /// </summary>
        public Action<T> registered;

        /// <summary>
        /// A callback invoked when an item is unregistered.
        /// </summary>
        public Action<T> unregistered;

        /// <summary>
        /// The amount of items registered in the list (Read only).
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// Returns the item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to return.</param>
        public T this[int index] => items[index];

        // Prevent use of default constructor.
        private Registry() {}

        /// <summary>
        /// Creates a new list with a set capacity.
        /// </summary>
        /// <param name="capacity">The initial capacity of the collection.</param>
        /// <param name="registered">The callback invoked when an item is registered.</param>
        /// <param name="unregistered">The callback invoked when an item is unregistered.</param>
        public Registry(int capacity, Action<T> registered = null, Action<T> unregistered = null)
        {
            this.items = new List<T>(capacity);
            this.registered = registered;
            this.unregistered = unregistered;
        }

        /// <summary>
        /// Creates a new list and pre-registers a list of items.
        /// </summary>
        /// <param name="items">The items to pre-register.</param>
        /// <param name="registered">The callback invoked when an item is registered.</param>
        /// <param name="unregistered">The callback invoked when an item is unregistered.</param>
        public Registry(T[] items, Action<T> registered = null, Action<T> unregistered = null)
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

        /// <summary>
        /// Registers an item in the list.
        /// </summary>
        /// <param name="item">The item to register.</param>
        /// <returns>True if the item was registered, false if the item cannot be registered.</returns>
        public bool Register(T item)
        {
            if (item == null || items.Contains(item)) {
                return false;
            }

            items.Add(item);
            registered?.Invoke(item);

            return true;
        }

        /// <summary>
        /// Unregisters an item from the list.
        /// </summary>
        /// <param name="item">The item to unregister.</param>
        /// <returns>True if the item was unregistered, false if the item cannot be unregistered.</returns>
        public bool Unregister(T item)
        {
            if (item == null || !items.Contains(item)) {
                return false;
            }

            items.Remove(item);
            unregistered?.Invoke(item);

            return true;
        }

        /// <summary>
        /// Unregisters all items from the list.
        /// </summary>
        public void Clear()
        {
            for (int i = items.Count - 1; i >= 0; i--) {
                Unregister(items[i]);
            }

            items.Clear();
        }

        /// <summary>
        /// Checks if a given item is registered in the list.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>True if the item is registered, false if the item is not registered.</returns>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

    }

}
