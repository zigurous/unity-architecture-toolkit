using System;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A number of game ticks. Tick counts cannot be negative. They are often
    /// used to represent timers within a tick system.
    /// </summary>
    public readonly struct TickCount : IComparable<TickCount>, IEquatable<TickCount>
    {
        /// <summary>
        /// The current tick count.
        /// </summary>
        public readonly int count;

        /// <summary>
        /// Creates a new tick count with the specified count.
        /// </summary>
        /// <param name="count">The tick count to set.</param>
        public TickCount(int count)
        {
            this.count = Math.Max(count, 0);
        }

        /// <summary>
        /// Compares this instance with another and returns an integer that
        /// indicates whether this instance precedes, follows, or appears in the
        /// same position in the sort order as the other instance.
        /// </summary>
        /// <param name="other">The other tick count to compare to.</param>
        /// <returns>
        /// Greater than zero if this instance follows the other, less than zero
        /// if this instance precedes the other, and zero if this instance has
        /// the same position as the other.
        /// </returns>
        public int CompareTo(TickCount other)
        {
            return count.CompareTo(other.count);
        }

        /// <summary>
        /// Checks if the tick count is equal to another tick count.
        /// </summary>
        /// <param name="other">The other tick count to compare.</param>
        /// <returns>True if the tick counts are equal, false otherwise.</returns>
        public bool Equals(TickCount other)
        {
            return count == other.count;
        }

        /// <summary>
        /// Converts the tick count to its string equivalent.
        /// </summary>
        /// <returns>The tick count as a string.</returns>
        public override string ToString()
        {
            return count.ToString();
        }

        public static implicit operator TickCount(int count) => new(count);
        public static implicit operator int(TickCount t) => t.count;
    }

}
