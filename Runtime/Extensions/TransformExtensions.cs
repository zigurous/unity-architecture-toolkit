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
        /// Transforms a point from local space to world space without scaling.
        /// </summary>
        /// <param name="transform">The transform to use for the transformation.</param>
        /// <param name="position">The local position to transform.</param>
        /// <returns>The transformed world position.</returns>
        public static Vector3 TransformPointUnscaled(this Transform transform, Vector3 position)
        {
            var localToWorldMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            return localToWorldMatrix.MultiplyPoint3x4(position);
        }

        /// <summary>
        /// Transforms a point from world space to local space without scaling.
        /// </summary>
        /// <param name="transform">The transform to use for the transformation.</param>
        /// <param name="position">The world position to transform.</param>
        /// <returns>The transformed local position.</returns>
        public static Vector3 InverseTransformPointUnscaled(this Transform transform, Vector3 position)
        {
            var worldToLocalMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one).inverse;
            return worldToLocalMatrix.MultiplyPoint3x4(position);
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
