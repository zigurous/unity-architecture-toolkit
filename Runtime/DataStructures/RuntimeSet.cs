using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A ScriptableObject that stores a list of items. A project asset can be
    /// created for the runtime set so it can be referenced throughout the
    /// application, but the items are added and removed at runtime.
    /// </summary>
    /// <typeparam name="T">The type of items to store.</typeparam>
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        /// <summary>
        /// The list of stored items in the set (Read only).
        /// </summary>
        public readonly List<T> items = new();

        /// <summary>
        /// The number of items in the set (Read only).
        /// </summary>
        public int Count => items != null ? items.Count : 0;

        /// <summary>
        /// Adds an item to the set if it is not already contained in the set.
        /// </summary>
        /// <param name="item">The item to add to the set.</param>
        public void Add(T item)
        {
            if (!items.Contains(item)) {
                items.Add(item);
            }
        }

        /// <summary>
        /// Removes an item from the set if it is contained in the set.
        /// </summary>
        /// <param name="item">The item to remove from the set.</param>
        public void Remove(T item)
        {
            if (items.Contains(item)) {
                items.Remove(item);
            }
        }

        /// <summary>
        /// Removes all items from the set.
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Checks if the given item is contained in the set.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>True if the item is contained in the set, false otherwise.</returns>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

    }

}
