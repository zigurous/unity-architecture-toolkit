namespace Zigurous.Architecture
{
    /// <summary>
    /// A type that can register and unregister modules.
    /// </summary>
    /// <typeparam name="T">The type of module that can be registered.</typeparam>
    public interface IModular<T>
        where T : class
    {
        /// <summary>
        /// Registers a module to the entity.
        /// </summary>
        /// <param name="module">The module to register.</param>
        /// <returns>True if the module was registered, false if the module cannot be registered.</returns>
        bool Register(T module);

        /// <summary>
        /// Unregisters a module from the entity.
        /// </summary>
        /// <param name="module">The module to unregister.</param>
        /// <returns>True if the module was unregistered, false if the module cannot be unregistered.</returns>
        bool Unregister(T module);

        /// <summary>
        /// Checks if a given module is registered.
        /// </summary>
        /// <param name="module">The module to check for registration.</param>
        /// <returns>True if the module is registered, false if the module is not registered.</returns>
        bool IsRegistered(T module);
    }

}
