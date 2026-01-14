using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Stores values using unique keys.
    /// </summary>
    public sealed class KeyValueStore
    {
        /// <summary>
        /// The id of the store.
        /// </summary>
        public readonly int id;

        private readonly Dictionary<int, IKeyValueStoreValue> store;

        private KeyValueStore() {}

        /// <summary>
        /// Creates a new key value store with the given id.
        /// </summary>
        /// <param name="id">The id of the store.</param>
        public KeyValueStore(int id)
        {
            this.id = id;
            this.store = new Dictionary<int, IKeyValueStoreValue>();
        }

        /// <summary>
        /// Gets the value for the given key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <returns>The value for the given key, or default if it does not exist in the store.</returns>
        public T GetValue<T>(int key) where T : class, IKeyValueStoreValue
        {
            if (store.TryGetValue(key, out IKeyValueStoreValue value)) {
                return value as T;
            } else {
                return default;
            }
        }

        /// <summary>
        /// Gets the value for the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <returns>The value for the given key, or default if it does not exist in the store.</returns>
        public TValue GetValue<TKey, TValue>(TKey key)
            where TKey : IKeyValueStoreKey
            where TValue : class, IKeyValueStoreValue
        {
            return GetValue<TValue>(key.storageKey);
        }

        /// <summary>
        /// Gets the boxed value for the given key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <returns>The value for the given key, or default if it does not exist in the store.</returns>
        public T GetBoxedValue<T>(int key) where T : struct
        {
            if (store.TryGetValue(key, out IKeyValueStoreValue value)) {
                return (value as BoxedKeyValueStoreValue<T>).value;
            } else {
                return default;
            }
        }

        /// <summary>
        /// Gets the boxed value for the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <returns>The value for the given key, or default if it does not exist in the store.</returns>
        public TValue GetBoxedValue<TKey, TValue>(TKey key)
            where TKey : IKeyValueStoreKey
            where TValue : struct
        {
            return GetBoxedValue<TValue>(key.storageKey);
        }

        /// <summary>
        /// Gets the value for the given key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <param name="value">The output value.</param>
        /// <returns>True if the value exists for the given key, false otherwise.</returns>
        public bool TryGetValue<T>(int key, out T value) where T : class, IKeyValueStoreValue
        {
            if (store.TryGetValue(key, out IKeyValueStoreValue stored))
            {
                value = stored as T;
                return value != null;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets the value for the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <param name="value">The output value.</param>
        /// <returns>True if the value exists for the given key, false otherwise.</returns>
        public bool TryGetValue<TKey, TValue>(TKey key, out TValue value)
            where TKey : IKeyValueStoreKey
            where TValue : class, IKeyValueStoreValue
        {
            return TryGetValue(key.storageKey, out value);
        }

        /// <summary>
        /// Gets the boxed value for the given key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <param name="value">The output value.</param>
        /// <returns>True if the value exists for the given key, false otherwise.</returns>
        public bool TryGetBoxedValue<T>(int key, out T value) where T : struct
        {
            if (store.TryGetValue(key, out IKeyValueStoreValue stored) && stored is BoxedKeyValueStoreValue<T> boxed)
            {
                value = boxed.value;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets the boxed value for the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <param name="value">The output value.</param>
        /// <returns>True if the value exists for the given key, false otherwise.</returns>
        public bool TryGetBoxedValue<TKey, TValue>(TKey key, out TValue value)
            where TKey : IKeyValueStoreKey
            where TValue : struct
        {
            return TryGetBoxedValue(key.storageKey, out value);
        }

        /// <summary>
        /// Sets the value for the given key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the value to set.</param>
        /// <param name="value">The value to set.</param>
        public void SetValue<T>(int key, T value) where T : class, IKeyValueStoreValue
        {
            store[key] = value;
        }

        /// <summary>
        /// Sets the value for the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="key">The key of the value to set.</param>
        /// <param name="value">The value to set.</param>
        public void SetValue<TKey, TValue>(TKey key, TValue value)
            where TKey : IKeyValueStoreKey
            where TValue : class, IKeyValueStoreValue
        {
            store[key.storageKey] = value;
        }

        /// <summary>
        /// Sets a boxed value for the given key.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="key">The key of the value to set.</param>
        /// <param name="value">The value to set.</param>
        public void SetBoxedValue<T>(int key, T value) where T : struct
        {
            if (store.TryGetValue(key, out IKeyValueStoreValue stored) && stored is BoxedKeyValueStoreValue<T> boxed)
            {
                boxed.value = value;
                store[key] = boxed;
            }
            else
            {
                store[key] = new BoxedKeyValueStoreValue<T>(value);
            }
        }

        /// <summary>
        /// Sets a boxed value for the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="key">The key of the value to set.</param>
        /// <param name="value">The value to set.</param>
        public void SetBoxedValue<TKey, TValue>(TKey key, TValue value)
            where TKey : IKeyValueStoreKey
            where TValue : struct
        {
            SetBoxedValue(key.storageKey, value);
        }

        /// <summary>
        /// Clears all values from the store.
        /// </summary>
        public void Clear()
        {
            store.Clear();
        }

    }

    /// <summary>
    /// A type of key that can be used in a key value store.
    /// </summary>
    public interface IKeyValueStoreKey
    {
        /// <summary>
        /// A unique storage key identifier.
        /// </summary>
        int storageKey { get; }
    }

    /// <summary>
    /// A type of value that can be stored in a key value store.
    /// </summary>
    public interface IKeyValueStoreValue
    {
    }

    /// <summary>
    /// A boxed value that is stored in a key value store.
    /// </summary>
    internal abstract class BoxedKeyValueStoreValue : IKeyValueStoreValue
    {
    }

    /// <summary>
    /// A boxed value that is stored in a key value store.
    /// </summary>
    /// <typeparam name="T">The type of value.</typeparam>
    internal class BoxedKeyValueStoreValue<T> : BoxedKeyValueStoreValue
    {
        /// <summary>
        /// The raw value being stored.
        /// </summary>
        public T value;

        /// <summary>
        /// Creates a new boxed value for the given raw value.
        /// </summary>
        /// <param name="value">The raw value to store.</param>
        public BoxedKeyValueStoreValue(T value)
        {
            this.value = value;
        }

    }

}
