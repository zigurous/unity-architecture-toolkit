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
        /// <returns>The located service instance.</returns>
        T Get<T>() where T : class;

        /// <summary>
        /// Locates and returns the service instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of service to locate.</typeparam>
        /// <param name="service">The located service instance as an output.</param>
        /// <returns>True if the service was located, false otherwise.</returns>
        bool TryGet<T>(out T service) where T : class;

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
        /// Unregisters the provided service from the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to unregister.</typeparam>
        /// <param name="service">The service to unregister.</param>
        void Unregister<T>(T service) where T : class;

        /// <summary>
        /// Checks if the type <typeparamref name="T"/> is registered to the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to check is registered.</typeparam>
        /// <returns>True if the type is registered, false otherwise.</returns>
        bool IsRegistered<T>() where T : class;

        /// <summary>
        /// Checks if the provided service is registered to the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to check is registered.</typeparam>
        /// <param name="service">The service to check is registered.</param>
        /// <returns>True if the service is registered, false otherwise.</returns>
        bool IsRegistered<T>(T service) where T : class;

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
        /// <returns>The located service instance.</returns>
        U Get<U>() where U : class, T;

        /// <summary>
        /// Locates and returns the service instance of type <typeparamref name="U"/>.
        /// </summary>
        /// <typeparam name="U">The type of service to locate.</typeparam>
        /// <param name="service">The located service instance as an output.</param>
        /// <returns>True if the service was located, false otherwise.</returns>
        bool TryGet<U>(out U service) where U : class, T;

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
        /// Unregisters the provided service from the service locator.
        /// </summary>
        /// <typeparam name="U">The type of service to unregister.</typeparam>
        /// <param name="service">The service to unregister.</param>
        void Unregister<U>(U service) where U : class, T;

        /// <summary>
        /// Checks if the type <typeparamref name="U"/> is registered to the service locator.
        /// </summary>
        /// <typeparam name="U">The type of service to check is registered.</typeparam>
        /// <returns>True if the type is registered, false otherwise.</returns>
        bool IsRegistered<U>() where U : class, T;

        /// <summary>
        /// Checks if the provided service is registered to the service locator.
        /// </summary>
        /// <typeparam name="U">The type of service to check is registered.</typeparam>
        /// <param name="service">The service to check is registered.</param>
        /// <returns>True if the service is registered, false otherwise.</returns>
        bool IsRegistered<U>(U service) where U : class, T;

        /// <summary>
        /// Clears all services from the service locator.
        /// </summary>
        void Clear();
    }

}
