using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A type that provides a central registry for obtaining service instances.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Locates and returns the service instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of service to locate.</typeparam>
        /// <returns>The registered service instance.</returns>
        T Get<T>() where T : class;

        /// <summary>
        /// Registers the service to the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to register.</typeparam>
        /// <param name="service">The service instance to register.</param>
        void Register<T>(T service) where T : class;

        /// <summary>
        /// Unregisters the type <typeparamref name="T"/> from the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to unregister.</typeparam>
        void Unregister<T>() where T : class;

        /// <summary>
        /// Checks if the type <typeparamref name="T"/> is registered to the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to check if registered.</typeparam>
        /// <returns>True if the type is registered, false otherwise.</returns>
        bool IsRegistered<T>() where T : class;

        /// <summary>
        /// Clears all services from the service locator.
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// A type that provides a central registry for obtaining service instances
    /// where each service conforms to type <typeparamref name="T"/>.
    /// </summary>
    public interface IServiceLocator<T> where T : class
    {
        /// <summary>
        /// Locates and returns the service instance of type <typeparamref name="U"/>.
        /// </summary>
        /// <typeparam name="U">The type of service to locate.</typeparam>
        /// <returns>The registered service instance.</returns>
        U Get<U>() where U : class, T;

        /// <summary>
        /// Registers the service to the service locator.
        /// </summary>
        /// <typeparam name="U">The type of service to register.</typeparam>
        /// <param name="service">The service instance to register.</param>
        void Register<U>(U service) where U : class, T;

        /// <summary>
        /// Unregisters the type <typeparamref name="U"/> from the service locator.
        /// </summary>
        /// <typeparam name="U">The type of service to unregister.</typeparam>
        void Unregister<U>() where U : class, T;

        /// <summary>
        /// Checks if the type <typeparamref name="U"/> is registered to the service locator.
        /// </summary>
        /// <typeparam name="U">The type of service to check if registered.</typeparam>
        /// <returns>True if the type is registered, false otherwise.</returns>
        bool IsRegistered<U>() where U : class, T;

        /// <summary>
        /// Clears all services from the service locator.
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// A central registry for obtaining service instances.
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> services;

        /// <summary>
        /// Creates a new instance of the service locator.
        /// </summary>
        public ServiceLocator()
        {
            services = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Creates a new instance of the service locator with an initial capacity.
        /// </summary>
        /// <param name="capacity">The initial capacity of services to allocate memory for.</param>
        public ServiceLocator(int capacity)
        {
            services = new Dictionary<Type, object>(capacity);
        }

        /// <inheritdoc/>
        public T Get<T>() where T : class
        {
            if (services.TryGetValue(typeof(T), out object service)) {
                return service as T;
            } else {
                return default;
            }
        }

        /// <inheritdoc/>
        public void Register<T>(T service) where T : class
        {
            services[typeof(T)] = service;
        }

        /// <inheritdoc/>
        public void Unregister<T>() where T : class
        {
            services.Remove(typeof(T));
        }

        /// <inheritdoc/>
        public bool IsRegistered<T>() where T : class
        {
            return services.ContainsKey(typeof(T));
        }

        /// <inheritdoc/>
        public void Clear()
        {
            services.Clear();
        }

    }

    /// <summary>
    /// A central registry for obtaining service instances where each service
    /// conforms to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type each service conforms to.</typeparam>
    public class ServiceLocator<T> : IServiceLocator<T> where T : class
    {
        private readonly Dictionary<Type, object> services;

        /// <summary>
        /// Creates a new instance of the service locator.
        /// </summary>
        public ServiceLocator()
        {
            services = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Creates a new instance of the service locator with an initial capacity.
        /// </summary>
        /// <param name="capacity">The initial capacity of services to allocate memory for.</param>
        public ServiceLocator(int capacity)
        {
            services = new Dictionary<Type, object>(capacity);
        }

        /// <inheritdoc/>
        public U Get<U>() where U : class, T
        {
            if (services.TryGetValue(typeof(U), out object service)) {
                return service as U;
            } else {
                return default;
            }
        }

        /// <inheritdoc/>
        public void Register<U>(U service) where U : class, T
        {
            services[typeof(U)] = service;
        }

        /// <inheritdoc/>
        public void Unregister<U>() where U : class, T
        {
            services.Remove(typeof(U));
        }

        /// <inheritdoc/>
        public bool IsRegistered<U>() where U : class, T
        {
            return services.ContainsKey(typeof(U));
        }

        /// <inheritdoc/>
        public void Clear()
        {
            services.Clear();
        }

    }

}
