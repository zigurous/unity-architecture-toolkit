using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for Unity objects.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Finds a reference to the specified object type in the scene. If the
        /// object reference is already assigned, then the current reference
        /// will be returned.
        /// </summary>
        /// <typeparam name="T">The type of object to find.</typeparam>
        /// <param name="obj">The object to find the reference for.</param>
        /// <returns>The reference to the object if it exists.</returns>
        public static T FindNonNullReference<T>(this T obj) where T : Object
        {
            if (obj == null) {
                obj = Object.FindObjectOfType<T>();
            }

            return obj;
        }

    }

}
