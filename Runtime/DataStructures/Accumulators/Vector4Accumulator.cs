using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates Vector4 values into a single total value.
    /// </summary>
    public sealed class Vector4Accumulator : ValueAccumulator<Vector4>
    {
        /// <inheritdoc/>
        protected override Vector4 DefaultValue => Vector4.zero;

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Vector4 Add(Vector4 value) => Total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector4 Subtract(Vector4 value) => Total - value;
    }

}
