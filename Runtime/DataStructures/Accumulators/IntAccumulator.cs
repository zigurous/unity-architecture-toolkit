namespace Zigurous.Architecture
{
    /// <summary>
    /// Accumulates int values into a single total value.
    /// </summary>
    public sealed class IntAccumulator : ValueAccumulator<int>
    {
        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override int Add(int value) => total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override int Subtract(int value) => total - value;
    }

}
