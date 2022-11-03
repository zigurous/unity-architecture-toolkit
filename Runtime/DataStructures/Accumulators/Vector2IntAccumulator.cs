using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates Vector2Int values into a single total value.
    /// </summary>
    public sealed class Vector2IntAccumulator : ValueAccumulator<Vector2Int>
    {
        /// <inheritdoc/>
        protected override Vector2Int defaultValue => Vector2Int.zero;

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Vector2Int Add(Vector2Int value) => total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector2Int Subtract(Vector2Int value) => total - value;
    }

}
