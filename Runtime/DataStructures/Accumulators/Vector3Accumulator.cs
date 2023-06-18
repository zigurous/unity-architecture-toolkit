using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates Vector3 values into a single total value.
    /// </summary>
    public sealed class Vector3Accumulator : ValueAccumulator<Vector3>
    {
        /// <inheritdoc/>
        protected override Vector3 DefaultValue => Vector3.zero;

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Vector3 Add(Vector3 value) => Total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector3 Subtract(Vector3 value) => Total - value;
    }

}
