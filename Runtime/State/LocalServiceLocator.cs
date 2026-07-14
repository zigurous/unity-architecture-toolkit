using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A local registry for obtaining service instances.
    /// </summary>
    public sealed class LocalServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> _services;

        /// <summary>
        /// Creates a new instance of the service locator.
        /// </summary>
        public LocalServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Creates a new instance of the service locator with an initial capacity.
        /// </summary>
        /// <param name="capacity">The initial capacity of services to allocate memory for.</param>
        public LocalServiceLocator(int capacity)
        {
            _services = new Dictionary<Type, object>(capacity);
        }

        ~LocalServiceLocator()
        {
            _services.Clear();
        }

        /// <inheritdoc/>
        public T Get<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out object service)) {
                return service as T;
            } else {
                return null;
            }
        }

        /// <inheritdoc/>
        public bool TryGet<T>(out T service) where T : class
        {
            if (_services.TryGetValue(typeof(T), out object registeredService)) {
                service = registeredService as T;
            } else {
                service = null;
            }

            return service != null;
        }

        /// <inheritdoc/>
        public void Register<T>(T service) where T : class
        {
            _services[typeof(T)] = service;
        }

        /// <inheritdoc/>
        public void Unregister<T>() where T : class
        {
            _services.Remove(typeof(T));
        }

        /// <inheritdoc/>
        public void Unregister<T>(T service) where T : class
        {
            if (IsRegistered(service)) {
                _services.Remove(typeof(T));
            }
        }

        /// <inheritdoc/>
        public bool IsRegistered<T>() where T : class
        {
            return _services.ContainsKey(typeof(T));
        }

        /// <inheritdoc/>
        public bool IsRegistered<T>(T service) where T : class
        {
            return _services.TryGetValue(typeof(T), out object registeredService) && registeredService == service;
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _services.Clear();
        }

    }

    /// <summary>
    /// A local registry for obtaining service instances where each service
    /// conforms to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type each service conforms to.</typeparam>
    public sealed class LocalServiceLocator<T> : IServiceLocator<T> where T : class
    {
        private readonly Dictionary<Type, object> _services;

        /// <summary>
        /// Creates a new instance of the service locator.
        /// </summary>
        public LocalServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Creates a new instance of the service locator with an initial capacity.
        /// </summary>
        /// <param name="capacity">The initial capacity of services to allocate memory for.</param>
        public LocalServiceLocator(int capacity)
        {
            _services = new Dictionary<Type, object>(capacity);
        }

        ~LocalServiceLocator()
        {
            _services.Clear();
        }

        /// <inheritdoc/>
        public U Get<U>() where U : class, T
        {
            if (_services.TryGetValue(typeof(U), out object service)) {
                return service as U;
            } else {
                return null;
            }
        }

        /// <inheritdoc/>
        public bool TryGet<U>(out U service) where U : class, T
        {
            if (_services.TryGetValue(typeof(U), out object registeredService)) {
                service = registeredService as U;
            } else {
                service = null;
            }

            return service != null;
        }

        /// <inheritdoc/>
        public void Register<U>(U service) where U : class, T
        {
            _services[typeof(U)] = service;
        }

        /// <inheritdoc/>
        public void Unregister<U>() where U : class, T
        {
            _services.Remove(typeof(U));
        }

        /// <inheritdoc/>
        public void Unregister<U>(U service) where U : class, T
        {
            if (IsRegistered(service)) {
                _services.Remove(typeof(U));
            }
        }

        /// <inheritdoc/>
        public bool IsRegistered<U>() where U : class, T
        {
            return _services.ContainsKey(typeof(U));
        }

        /// <inheritdoc/>
        public bool IsRegistered<U>(U service) where U : class, T
        {
            return _services.TryGetValue(typeof(U), out object registeredService) && registeredService == service;
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _services.Clear();
        }

    }

}
