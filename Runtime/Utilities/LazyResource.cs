using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Lazy loads a Unity resource from a given path.
    /// </summary>
    /// <typeparam name="T">The type of object to load.</typeparam>
    public class LazyResource<T> where T : Object
    {
        /// <summary>
        /// The path to the target resource.
        /// </summary>
        public readonly string path;

        private T m_Resource;

        /// <summary>
        /// The loaded resource.
        /// </summary>
        public T resource
        {
            get
            {
                if (m_Resource == null) {
                    m_Resource = Resources.Load<T>(path);
                }
                return m_Resource;
            }
        }

        private LazyResource() {}

        /// <summary>
        /// Creates a new lazy resource for the given path.
        /// </summary>
        /// <param name="resourcePath">The path to the target resource.</param>
        public LazyResource(string resourcePath)
        {
            path = resourcePath;
        }

        /// <summary>
        /// Implicitly converts the property to the resource type.
        /// </summary>
        /// <param name="property">The property containing the resource.</param>
        /// <returns>The resource as its provided type.</returns>
        public static implicit operator T(LazyResource<T> property) => property.resource;

    }

}
