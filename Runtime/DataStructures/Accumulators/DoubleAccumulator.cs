namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates double values into a single total value.
    /// </summary>
    public sealed class DoubleAccumulator : ValueAccumulator<double>
    {
        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override double Add(double value) => Total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override double Subtract(double value) => Total - value;
    }

}
