using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for Transform components.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Determines if the transform or any of its parents has changed since
        /// the last time the flag was set to false.
        /// </summary>
        /// <param name="transform">The transform to check.</param>
        /// <returns>True if the transform or any of its parents has changed.</returns>
        public static bool HasChangedInHierarchy(this Transform transform)
        {
            if (transform.parent != null) {
                return transform.parent.HasChangedInHierarchy();
            } else {
                return transform.hasChanged;
            }
        }

        /// <summary>
        /// Resets the position, rotation, and scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        public static void Reset(this Transform transform)
        {
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Resets the local position, rotation, and scale of the transform.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        public static void ResetLocal(this Transform transform)
        {
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;
        }

    }

}
