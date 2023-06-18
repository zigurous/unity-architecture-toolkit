using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates Quaternion values into a single total value.
    /// </summary>
    public sealed class QuaternionAccumulator : ValueAccumulator<Quaternion>
    {
        /// <inheritdoc/>
        protected override Quaternion DefaultValue => Quaternion.identity;

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Quaternion Add(Quaternion value) => Total * value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Quaternion Subtract(Quaternion value) => Total * Quaternion.Inverse(value);
    }

}
