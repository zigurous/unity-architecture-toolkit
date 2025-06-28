using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An equality comparer for Vector2Int that produces a lower rate of hash
    /// collisions thus improving performance with lists and dictionaries.
    /// </summary>
    public class FastVector2IntEqualityComparer : IEqualityComparer<Vector2Int>
    {
        /// <summary>
        /// The default equality comparer.
        /// </summary>
        public static readonly FastVector2IntEqualityComparer Default = new();

        /// <summary>
        /// Checks the equality of two Vector2Int values.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>True if the values are equal, false otherwise.</returns>
        public bool Equals(Vector2Int a, Vector2Int b)
        {
            return a.x == b.x && a.y == b.y;
        }

        /// <summary>
        /// Returns a hash code for the Vector2Int value.
        /// </summary>
        /// <param name="v">The value to get the hash code for.</param>
        /// <returns>The hash code for the value.</returns>
        public int GetHashCode(Vector2Int v)
        {
            return v.x << 16 | (v.y & 0xFFFF);
        }

    }

}
