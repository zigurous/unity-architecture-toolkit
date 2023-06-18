using System;
using UnityEngine;

namespace Zigurous.Architecture.Structs
{
    /// <summary>
    /// Stores the size of an entity as a width and height.
    /// </summary>
    [System.Serializable]
    public struct Size : IEquatable<Size>, IComparable<Size>
    {
        /// <summary>
        /// Shorthand for writing <c>Size(0, 0)</c>.
        /// </summary>
        public static Size zero => new Size(0, 0);

        /// <summary>
        /// Shorthand for writing <c>Size(1, 1)</c>.
        /// </summary>
        public static Size one => new Size(1, 1);

        /// <summary>
        /// Shorthand for writing <c>Size(int.MaxValue, int.MaxValue)</c>.
        /// </summary>
        public static Size max => new Size(int.MaxValue, int.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>Size(2)</c>.
        /// </summary>
        public static Size sq2 => new Size(2);

        /// <summary>
        /// Shorthand for writing <c>Size(4)</c>.
        /// </summary>
        public static Size sq4 => new Size(4);

        /// <summary>
        /// Shorthand for writing <c>Size(8)</c>.
        /// </summary>
        public static Size sq8 => new Size(8);

        /// <summary>
        /// Shorthand for writing <c>Size(16)</c>.
        /// </summary>
        public static Size sq16 => new Size(16);

        /// <summary>
        /// Shorthand for writing <c>Size(32)</c>.
        /// </summary>
        public static Size sq32 => new Size(32);

        /// <summary>
        /// Shorthand for writing <c>Size(64)</c>.
        /// </summary>
        public static Size sq64 => new Size(64);

        /// <summary>
        /// Shorthand for writing <c>Size(128)</c>.
        /// </summary>
        public static Size sq128 => new Size(128);

        /// <summary>
        /// Shorthand for writing <c>Size(256)</c>.
        /// </summary>
        public static Size sq256 => new Size(256);

        /// <summary>
        /// Shorthand for writing <c>Size(512)</c>.
        /// </summary>
        public static Size sq512 => new Size(512);

        /// <summary>
        /// Shorthand for writing <c>Size(1024)</c>.
        /// </summary>
        public static Size sq1024 => new Size(1024);

        /// <summary>
        /// Shorthand for writing <c>Size(2048)</c>.
        /// </summary>
        public static Size sq2048 => new Size(2048);

        /// <summary>
        /// Shorthand for writing <c>Size(4096)</c>.
        /// </summary>
        public static Size sq4096 => new Size(4096);

        /// <summary>
        /// Shorthand for writing <c>Size(8192)</c>.
        /// </summary>
        public static Size sq8192 => new Size(8192);

        /// <summary>
        /// The width of the entity.
        /// </summary>
        [Tooltip("The width of the entity.")]
        public int width;

        /// <summary>
        /// The height of the entity.
        /// </summary>
        [Tooltip("The height of the entity.")]
        public int height;

        /// <summary>
        /// The area of the entity (width * height) (Read only).
        /// </summary>
        public int area => System.Math.Abs(width * height);

        /// <summary>
        /// Creates a new size with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the entity.</param>
        /// <param name="height">The height of the entity.</param>
        public Size(int width = 0, int height = 0)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a new size with uniform width and height.
        /// </summary>
        /// <param name="size">The uniform size of the entity.</param>
        public Size(int size)
        {
            this.width = size;
            this.height = size;
        }

        /// <summary>
        /// Compares this instance with another and returns an integer that
        /// indicates whether this instance precedes, follows, or appears in the
        /// same position in the sort order as the other instance.
        /// </summary>
        /// <param name="other">The size to compare to.</param>
        /// <returns>
        /// Greater than zero if this instance follows the other, less than zero
        /// if this instance precedes the other, and zero if this instance has
        /// the same position as the other.
        /// </returns>
        public int CompareTo(Size other)
        {
            int a = this.area;
            int b = other.area;

            if (a == b) return 0;
            else if (a > b) return 1;
            else return -1;
        }

        /// <summary>
        /// Determines if the size is equal to another size.
        /// </summary>
        /// <param name="other">The size to compare to.</param>
        /// <returns>True if the sizes are equal, false otherwise.</returns>
        public bool Equals(Size other)
        {
            return this.width == other.width &&
                   this.height == other.height;
        }

        /// <summary>
        /// Determines if the size is equal to another size.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        /// <returns>True if the sizes are equal, false otherwise.</returns>
        public override bool Equals(object other)
        {
            if (other is Size size) {
                return Equals(size);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the size.
        /// </summary>
        /// <returns>The hash code of the size.</returns>
        public override int GetHashCode()
        {
            return (width, height).GetHashCode();
        }

        /// <summary>
        /// Converts the size to a string.
        /// </summary>
        /// <returns>The size as a string.</returns>
        public override string ToString()
        {
            return $"{width.ToString()}x{height.ToString()}";
        }

        /// <summary>
        /// Determines if two sizes are equal.
        /// </summary>
        /// <param name="lhs">The first size to compare.</param>
        /// <param name="rhs">The second size to compare.</param>
        /// <returns>True if the sizes are equal, false otherwise.</returns>
        public static bool operator ==(Size lhs, Size rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Determines if two sizes are not equal.
        /// </summary>
        /// <param name="lhs">The first size to compare.</param>
        /// <param name="rhs">The second size to compare.</param>
        /// <returns>True if the sizes are not equal, false otherwise.</returns>
        public static bool operator !=(Size lhs, Size rhs) => !lhs.Equals(rhs);

    }

}
