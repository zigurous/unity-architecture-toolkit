using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Stores the size of a grid as rows and columns.
    /// </summary>
    [System.Serializable]
    public struct GridSize : IEquatable<GridSize>, IComparable<GridSize>
    {
        /// <summary>
        /// Shorthand for writing <c>GridSize(0, 0)</c>.
        /// </summary>
        public static GridSize zero => new(0, 0);

        /// <summary>
        /// Shorthand for writing <c>GridSize(1, 1)</c>.
        /// </summary>
        public static GridSize one => new(1, 1);

        /// <summary>
        /// Shorthand for writing <c>GridSize(int.MaxValue, int.MaxValue)</c>.
        /// </summary>
        public static GridSize max => new(int.MaxValue, int.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>GridSize(2)</c>.
        /// </summary>
        public static GridSize sq2 => new(2);

        /// <summary>
        /// Shorthand for writing <c>GridSize(4)</c>.
        /// </summary>
        public static GridSize sq4 => new(4);

        /// <summary>
        /// Shorthand for writing <c>GridSize(8)</c>.
        /// </summary>
        public static GridSize sq8 => new(8);

        /// <summary>
        /// Shorthand for writing <c>GridSize(16)</c>.
        /// </summary>
        public static GridSize sq16 => new(16);

        /// <summary>
        /// Shorthand for writing <c>GridSize(32)</c>.
        /// </summary>
        public static GridSize sq32 => new(32);

        /// <summary>
        /// Shorthand for writing <c>GridSize(64)</c>.
        /// </summary>
        public static GridSize sq64 => new(64);

        /// <summary>
        /// Shorthand for writing <c>GridSize(128)</c>.
        /// </summary>
        public static GridSize sq128 => new(128);

        /// <summary>
        /// Shorthand for writing <c>GridSize(256)</c>.
        /// </summary>
        public static GridSize sq256 => new(256);

        /// <summary>
        /// Shorthand for writing <c>GridSize(512)</c>.
        /// </summary>
        public static GridSize sq512 => new(512);

        /// <summary>
        /// Shorthand for writing <c>GridSize(1024)</c>.
        /// </summary>
        public static GridSize sq1024 => new(1024);

        /// <summary>
        /// Shorthand for writing <c>GridSize(2048)</c>.
        /// </summary>
        public static GridSize sq2048 => new(2048);

        /// <summary>
        /// Shorthand for writing <c>GridSize(4096)</c>.
        /// </summary>
        public static GridSize sq4096 => new(4096);

        /// <summary>
        /// Shorthand for writing <c>GridSize(8192)</c>.
        /// </summary>
        public static GridSize sq8192 => new(8192);

        /// <summary>
        /// The number of rows in the grid.
        /// </summary>
        [Tooltip("The number of rows in the grid.")]
        public int rows;

        /// <summary>
        /// The number of columns in the grid.
        /// </summary>
        [Tooltip("The number of columns in the grid.")]
        public int columns;

        /// <summary>
        /// The area of the grid (rows * columns) (Read only).
        /// </summary>
        public readonly int Area => Math.Abs(rows * columns);

        /// <summary>
        /// Creates a new grid size with the specified rows and columns.
        /// </summary>
        /// <param name="rows">The number of rows in the grid.</param>
        /// <param name="columns">The number of columns in the grid.</param>
        public GridSize(int rows = 0, int columns = 0)
        {
            this.rows = rows;
            this.columns = columns;
        }

        /// <summary>
        /// Creates a new grid size with uniform rows and columns.
        /// </summary>
        /// <param name="size">The uniform size of the grid.</param>
        public GridSize(int size)
        {
            rows = size;
            columns = size;
        }

        /// <summary>
        /// Compares this instance with another and returns an integer that
        /// indicates whether this instance precedes, follows, or appears in the
        /// same position in the sort order as the other instance.
        /// </summary>
        /// <param name="other">The grid size to compare to.</param>
        /// <returns>
        /// Greater than zero if this instance follows the other, less than zero
        /// if this instance precedes the other, and zero if this instance has
        /// the same position as the other.
        /// </returns>
        public readonly int CompareTo(GridSize other)
        {
            int a = Area;
            int b = other.Area;

            if (a == b) return 0;
            else if (a > b) return 1;
            else return -1;
        }

        /// <summary>
        /// Checks if the grid size is equal to another grid size.
        /// </summary>
        /// <param name="other">The grid size to compare to.</param>
        /// <returns>True if the grid sizes are equal, false otherwise.</returns>
        public readonly bool Equals(GridSize other)
        {
            return rows == other.rows &&
                   columns == other.columns;
        }

        /// <summary>
        /// Checks if the grid size is equal to another grid size.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        /// <returns>True if the grid sizes are equal, false otherwise.</returns>
        public override readonly bool Equals(object other)
        {
            if (other is GridSize size) {
                return Equals(size);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the grid size.
        /// </summary>
        /// <returns>The hash code of the grid size.</returns>
        public override readonly int GetHashCode()
        {
            return System.HashCode.Combine(rows, columns);
        }

        /// <summary>
        /// Converts the grid size to a string.
        /// </summary>
        /// <returns>The grid size as a string.</returns>
        public override readonly string ToString()
        {
            return $"{rows}x{columns}";
        }

        /// <summary>
        /// Determines if two grid sizes are equal.
        /// </summary>
        /// <param name="lhs">The first grid size to compare.</param>
        /// <param name="rhs">The second grid size to compare.</param>
        /// <returns>True if the grid sizes are equal, false otherwise.</returns>
        public static bool operator ==(GridSize lhs, GridSize rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Determines if two grid sizes are not equal.
        /// </summary>
        /// <param name="lhs">The first grid size to compare.</param>
        /// <param name="rhs">The second grid size to compare.</param>
        /// <returns>True if the grid sizes are not equal, false otherwise.</returns>
        public static bool operator !=(GridSize lhs, GridSize rhs) => !lhs.Equals(rhs);

    }

}
