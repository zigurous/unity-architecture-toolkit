using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates Vector2 values into a single total value.
    /// </summary>
    public sealed class Vector2Accumulator : ValueAccumulator<Vector2>
    {
        /// <inheritdoc/>
        protected override Vector2 defaultValue => Vector2.zero;

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Vector2 Add(Vector2 value) => total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector2 Subtract(Vector2 value) => total - value;
    }

}
