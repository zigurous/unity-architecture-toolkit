using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A singleton that manages key value stores.
    /// </summary>
    public sealed class StoreManager : Singleton<StoreManager>
    {
        private readonly Dictionary<int, KeyValueStore> stores = new();

        /// <summary>
        /// Retrieves the key value store with the given id, or creates a new
        /// store if not yet created.
        /// </summary>
        /// <param name="id">The id of the store.</param>
        /// <returns>The key value store for the given id.</returns>
        public KeyValueStore GetStore(int id)
        {
            if (stores.TryGetValue(id, out KeyValueStore store)) {
                return store;
            }

            store = new KeyValueStore(id);
            stores[id] = store;
            return store;
        }

        /// <summary>
        /// Deletes the key value store with the given id.
        /// </summary>
        /// <param name="id">The id of the store to delete.</param>
        public void Delete(int id)
        {
            if (stores.TryGetValue(id, out KeyValueStore store))
            {
                store.Clear();
                stores.Remove(id);
            }
        }

    }

}
