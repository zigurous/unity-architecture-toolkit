using System;
using UnityEngine;

namespace Zigurous.Architecture.Structs
{
    /// <summary>
    /// A bitmask representation that can be used for bitwise operations.
    /// A bitmask is a set of bits that can be set or cleared.
    /// </summary>
    [Serializable]
    public struct Bitmask : IEquatable<Bitmask>, IEquatable<int>
    {
        /// <summary>
        /// The bitmask represented as a 32-bit integer.
        /// </summary>
        [SerializeField]
        private int mask;

        /// <summary>
        /// Creates a new Bitmask from the given 32-bit integer.
        /// </summary>
        /// <param name="mask">The 32-bit integer to represent as a bitmask.</param>
        public Bitmask(int mask)
        {
            this.mask = mask;
        }

        /// <summary>
        /// Checks if the bitmask contains the flag.
        /// <code>(mask &amp; flag) == flag</code>
        /// </summary>
        /// <param name="flag">The flag to check for.</param>
        /// <returns>True if the bitmask contains the flag, false otherwise.</returns>
        public bool HasFlag(int flag)
        {
            return (mask & flag) == flag;
        }

        /// <summary>
        /// Checks if the bitmask contains any of the flags.
        /// <code>(mask &amp; flags) != 0</code>
        /// </summary>
        /// <param name="flags">The flags to check for.</param>
        /// <returns>True if the bitmask contains any of the flags, false otherwise.</returns>
        public bool HasAnyFlag(int flags)
        {
            return (mask & flags) != 0;
        }

        /// <summary>
        /// Checks if the bitmask contains only the given flags
        /// and no other flags.
        /// <code>((mask ^ flags) &amp; flags) == 0</code>
        /// </summary>
        /// <param name="flags">The flags to check for.</param>
        /// <returns>True if the bitmask contains only the given flags, false otherwise.</returns>
        public bool HasOnlyFlags(int flags)
        {
            return ((mask ^ flags) & flags) == 0;
        }

        /// <summary>
        /// Checks if the nth bit of the bitmask is set.
        /// </summary>
        /// <param name="n">The nth bit to check for.</param>
        /// <returns>True if the nth bit is set, false otherwise.</returns>
        public bool Has(int n)
        {
            return Get(n) != 0;
        }

        /// <summary>
        /// Returns the nth bit of the bitmask.
        /// </summary>
        /// <param name="n">The nth bit to get.</param>
        /// <returns>The nth bit of the bitmask.</returns>
        public int Get(int n)
        {
            return (mask >> n) & 1;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to 1.
        /// </summary>
        /// <param name="n">The nth bit to set.</param>
        public void Set(int n)
        {
            mask |= 1 << n;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to 0.
        /// </summary>
        /// <param name="n">The nth bit to clear.</param>
        public void Clear(int n)
        {
            mask &= ~(1 << n);
        }

        /// <summary>
        /// Toggles the nth bit of the bitmask.
        /// </summary>
        /// <param name="n">The nth bit to toggle.</param>
        public void Toggle(int n)
        {
            mask ^= 1 << n;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to x.
        /// </summary>
        /// <param name="n">The nth bit to set.</param>
        /// <param name="x">The value to set the bit to.</param>
        public void Change(int n, int x)
        {
            mask = (mask & ~(1 << n)) | (x << n);
        }

        /// <summary>
        /// Determines if the bitmask is equal to another bitmask.
        /// </summary>
        /// <param name="other">The bitmask to compare to.</param>
        /// <returns>True if the bitmasks are equal, false otherwise.</returns>
        public bool Equals(Bitmask other)
        {
            return this.mask == other.mask;
        }

        /// <summary>
        /// Determines if the bitmask is equal to another bitmask.
        /// </summary>
        /// <param name="other">The bitmask to compare to.</param>
        /// <returns>True if the bitmasks are equal, false otherwise.</returns>
        public bool Equals(int other)
        {
            return this.mask == other;
        }

        /// <summary>
        /// Determines if the bitmask is equal to another bitmask.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        /// <returns>True if the bitmasks are equal, false otherwise.</returns>
        public override bool Equals(object other)
        {
            if (other is Bitmask bitmask) {
                return Equals(bitmask);
            } else if (other is int integer) {
                return Equals(integer);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the bitmask.
        /// </summary>
        /// <returns>The hash code of the bitmask.</returns>
        public override int GetHashCode()
        {
            return mask.GetHashCode();
        }

        /// <summary>
        /// Converts the bitmask to a string.
        /// </summary>
        /// <returns>The bitmask as a string.</returns>
        public override string ToString()
        {
            string binary = System.Convert.ToString(mask, 2);
            return binary.PadLeft(32, '0');
        }

        /// <summary>
        /// Determines if two bitmasks are equal.
        /// </summary>
        /// <param name="lhs">The first bitmask to compare.</param>
        /// <param name="rhs">The second bitmask to compare.</param>
        /// <returns>True if the bitmasks are equal, false otherwise.</returns>
        public static bool operator ==(Bitmask lhs, Bitmask rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Determines if two bitmasks are equal.
        /// </summary>
        /// <param name="lhs">The first bitmask to compare.</param>
        /// <param name="rhs">The second bitmask to compare.</param>
        /// <returns>True if the bitmasks are equal, false otherwise.</returns>
        public static bool operator ==(Bitmask lhs, int rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Determines if two bitmasks are equal.
        /// </summary>
        /// <param name="lhs">The first bitmask to compare.</param>
        /// <param name="rhs">The second bitmask to compare.</param>
        /// <returns>True if the bitmasks are equal, false otherwise.</returns>
        public static bool operator ==(int lhs, Bitmask rhs) => rhs.Equals(lhs);

        /// <summary>
        /// Determines if two bitmasks are not equal.
        /// </summary>
        /// <param name="lhs">The first bitmask to compare.</param>
        /// <param name="rhs">The second bitmask to compare.</param>
        /// <returns>True if the bitmasks are not equal, false otherwise.</returns>
        public static bool operator !=(Bitmask lhs, Bitmask rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Determines if two bitmasks are not equal.
        /// </summary>
        /// <param name="lhs">The first bitmask to compare.</param>
        /// <param name="rhs">The second bitmask to compare.</param>
        /// <returns>True if the bitmasks are not equal, false otherwise.</returns>
        public static bool operator !=(Bitmask lhs, int rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Determines if two bitmasks are not equal.
        /// </summary>
        /// <param name="lhs">The first bitmask to compare.</param>
        /// <param name="rhs">The second bitmask to compare.</param>
        /// <returns>True if the bitmasks are not equal, false otherwise.</returns>
        public static bool operator !=(int lhs, Bitmask rhs) => !rhs.Equals(lhs);

        /// <summary>
        /// Performs a bitwise AND operation on two bitmasks.
        /// </summary>
        /// <param name="lhs">The first bitmask.</param>
        /// <param name="rhs">The second bitmask.</param>
        /// <returns>The result of the operation.</returns>
        public static Bitmask operator &(Bitmask lhs, Bitmask rhs) => new Bitmask(lhs.mask & rhs.mask);

        /// <summary>
        /// Performs a bitwise OR operation on two bitmasks.
        /// </summary>
        /// <param name="lhs">The first bitmask.</param>
        /// <param name="rhs">The second bitmask.</param>
        /// <returns>The result of the operation.</returns>
        public static Bitmask operator |(Bitmask lhs, Bitmask rhs) => new Bitmask(lhs.mask | rhs.mask);

        /// <summary>
        /// Performs a bitwise XOR operation on two bitmasks.
        /// </summary>
        /// <param name="lhs">The first bitmask.</param>
        /// <param name="rhs">The second bitmask.</param>
        /// <returns>The result of the operation.</returns>
        public static Bitmask operator ^(Bitmask lhs, Bitmask rhs) => new Bitmask(lhs.mask ^ rhs.mask);

        /// <summary>
        /// Performs a bitwise ones' complement operation on a bitmask.
        /// </summary>
        /// <param name="lhs">The first bitmask.</param>
        /// <param name="rhs">The second bitmask.</param>
        /// <returns>The result of the operation.</returns>
        public static Bitmask operator ~(Bitmask operand) => new Bitmask(~operand.mask);

        /// <summary>
        /// Performs a binary left shift operation on two bitmasks.
        /// </summary>
        /// <param name="lhs">The first bitmask.</param>
        /// <param name="rhs">The second bitmask.</param>
        /// <returns>The result of the operation.</returns>
        public static Bitmask operator <<(Bitmask lhs, int rhs) => new Bitmask(lhs.mask << rhs);

        /// <summary>
        /// Performs a binary right shift operation on two bitmasks.
        /// </summary>
        /// <param name="lhs">The first bitmask.</param>
        /// <param name="rhs">The second bitmask.</param>
        /// <returns>The result of the operation.</returns>
        public static Bitmask operator >>(Bitmask lhs, int rhs) => new Bitmask(lhs.mask >> rhs);

        /// <summary>
        /// Implicitly converts a bitmask to an integer.
        /// </summary>
        /// <param name="bitmask">The bitmask to convert.</param>
        /// <returns>The bitmask as an integer.</returns>
        public static implicit operator int(Bitmask bitmask) => bitmask.mask;

        /// <summary>
        /// Implicitly converts an integer to a bitmask.
        /// </summary>
        /// <param name="mask">The integer to convert.</param>
        /// <returns>The integer as a bitmask.</returns>
        public static implicit operator Bitmask(int mask) => new Bitmask(mask);

    }

}
