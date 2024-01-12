using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Stores a tuple of 3 booleans.
    /// </summary>
    [System.Serializable]
    public struct Bool3 : IEquatable<Bool3>
    {
        /// <summary>
        /// Shorthand for writing <c>Bool3(false, false, false)</c>.
        /// </summary>
        public static Bool3 False => new(false, false, false);

        /// <summary>
        /// Shorthand for writing <c>Bool3(true, true, true)</c>.
        /// </summary>
        public static Bool3 True => new(true, true, true);

        /// <summary>
        /// Shorthand for writing <c>Bool3(true, false, false)</c>.
        /// </summary>
        public static Bool3 X => new(true, false, false);

        /// <summary>
        /// Shorthand for writing <c>Bool3(false, true, false)</c>.
        /// </summary>
        public static Bool3 Y => new(false, true, false);

        /// <summary>
        /// Shorthand for writing <c>Bool3(false, false, true)</c>.
        /// </summary>
        public static Bool3 Z => new(false, false, true);

        /// <summary>
        /// The X component.
        /// </summary>
        [Tooltip("The X component.")]
        public bool x;

        /// <summary>
        /// The Y component.
        /// </summary>
        [Tooltip("The Y component.")]
        public bool y;

        /// <summary>
        /// The Z component.
        /// </summary>
        [Tooltip("The Z component.")]
        public bool z;

        /// <summary>
        /// Gets or sets the component at the specified index.
        /// </summary>
        /// <param name="index">The index of the component to get or set.</param>
        public bool this[int index]
        {
            readonly get
            {
                return index switch
                {
                    0 => x,
                    1 => y,
                    2 => z,
                    _ => throw new IndexOutOfRangeException(),
                };
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Creates a new Bool3 with the specified values.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        public Bool3(bool x = false, bool y = false, bool z = false)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Determines if the tuple is equal to another.
        /// </summary>
        /// <param name="other">The tuple to compare to.</param>
        /// <returns>True if the tuples are equal, false otherwise.</returns>
        public readonly bool Equals(Bool3 other)
        {
            return x == other.x &&
                   y == other.y &&
                   z == other.z;
        }

        /// <summary>
        /// Determines if the tuple is equal to another.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        /// <returns>True if the tuples are equal, false otherwise.</returns>
        public override readonly bool Equals(object other)
        {
            if (other is Bool3 bool3) {
                return Equals(bool3);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the tuple.
        /// </summary>
        /// <returns>The hash code of the tuple.</returns>
        public override readonly int GetHashCode()
        {
            return System.HashCode.Combine(x, y, z);
        }

        /// <summary>
        /// Converts the tuple to a string.
        /// </summary>
        /// <returns>The tuple as a string.</returns>
        public override readonly string ToString()
        {
            return $"{x}, {y}, {z}";
        }

        /// <summary>
        /// Determines if two tuples are equal.
        /// </summary>
        /// <param name="lhs">The first tuple to compare.</param>
        /// <param name="rhs">The second tuple to compare.</param>
        /// <returns>True if the tuples are equal, false otherwise.</returns>
        public static bool operator ==(Bool3 lhs, Bool3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Determines if two tuples are not equal.
        /// </summary>
        /// <param name="lhs">The first tuple to compare.</param>
        /// <param name="rhs">The second tuple to compare.</param>
        /// <returns>True if the tuples are not equal, false otherwise.</returns>
        public static bool operator !=(Bool3 lhs, Bool3 rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Performs a bitwise AND operation on two tuples.
        /// </summary>
        /// <param name="lhs">The first tuple.</param>
        /// <param name="rhs">The second tuple.</param>
        /// <returns>The result of the operation.</returns>
        public static Bool3 operator &(Bool3 lhs, Bool3 rhs) => new(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);

        /// <summary>
        /// Performs a bitwise OR operation on two tuples.
        /// </summary>
        /// <param name="lhs">The first tuple.</param>
        /// <param name="rhs">The second tuple.</param>
        /// <returns>The result of the operation.</returns>
        public static Bool3 operator |(Bool3 lhs, Bool3 rhs) => new(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);

        /// <summary>
        /// Performs a bitwise XOR operation on two tuples.
        /// </summary>
        /// <param name="lhs">The first tuple.</param>
        /// <param name="rhs">The second tuple.</param>
        /// <returns>The result of the operation.</returns>
        public static Bool3 operator ^(Bool3 lhs, Bool3 rhs) => new(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);

        /// <summary>
        /// Performs a logical negation operation on a tuple.
        /// </summary>
        /// <param name="operand">The tuple to negate.</param>
        /// <returns>The result of the operation.</returns>
        public static Bool3 operator !(Bool3 operand) => new(!operand.x, !operand.y, !operand.z);

    }

}
