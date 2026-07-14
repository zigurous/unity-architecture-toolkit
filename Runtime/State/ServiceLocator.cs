using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A central registry for obtaining service instances.
    /// </summary>
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        /// <summary>
        /// Locates and returns the service instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of service to locate.</typeparam>
        /// <returns>The located service instance.</returns>
        public static T Get<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out object service)) {
                return service as T;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Locates and returns the service instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of service to locate.</typeparam>
        /// <param name="service">The located service instance as an output.</param>
        /// <returns>True if the service was located, false otherwise.</returns>
        public static bool TryGet<T>(out T service) where T : class
        {
            if (_services.TryGetValue(typeof(T), out object registeredService)) {
                service = registeredService as T;
            } else {
                service = null;
            }

            return service != null;
        }

        /// <summary>
        /// Registers the service to the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to register.</typeparam>
        /// <param name="service">The service instance to register.</param>
        public static void Register<T>(T service) where T : class
        {
            _services[typeof(T)] = service;
        }

        /// <summary>
        /// Unregisters the type <typeparamref name="T"/> from the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to unregister.</typeparam>
        public static void Unregister<T>() where T : class
        {
            _services.Remove(typeof(T));
        }

        /// <summary>
        /// Unregisters the provided service from the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to unregister.</typeparam>
        /// <param name="service">The service to unregister.</param>
        public static void Unregister<T>(T service) where T : class
        {
            if (IsRegistered(service)) {
                _services.Remove(typeof(T));
            }
        }

        /// <summary>
        /// Checks if the type <typeparamref name="T"/> is registered to the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to check is registered.</typeparam>
        /// <returns>True if the type is registered, false otherwise.</returns>
        public static bool IsRegistered<T>() where T : class
        {
            return _services.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Checks if the provided service is registered to the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to check is registered.</typeparam>
        /// <param name="service">The service to check is registered.</param>
        /// <returns>True if the service is registered, false otherwise.</returns>
        public static bool IsRegistered<T>(T service) where T : class
        {
            return _services.TryGetValue(typeof(T), out object registeredService) && registeredService == service;
        }

        /// <summary>
        /// Clears all services from the service locator.
        /// </summary>
        public static void Clear()
        {
            _services.Clear();
        }

    }

}
