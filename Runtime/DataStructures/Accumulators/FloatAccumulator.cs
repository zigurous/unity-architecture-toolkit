namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates float values into a single total value.
    /// </summary>
    public sealed class FloatAccumulator : ValueAccumulator<float>
    {
        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override float Add(float value) => Total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override float Subtract(float value) => Total - value;
    }

}
