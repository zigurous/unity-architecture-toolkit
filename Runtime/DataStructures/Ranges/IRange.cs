namespace Zigurous.Architecture
{
    /// <summary>
    /// A generic interface for a range of values.
    /// </summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    public interface IRange<T>
    {
        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        T min { get; set; }

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        T max { get; set; }

        /// <summary>
        /// Checks if a value is in the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the value is in the range, false otherwise.</returns>
        bool Includes(T value);

        /// <summary>
        /// Checks if a value is in the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="includeMin">The minimum value is inclusive if true, exclusive if false.</param>
        /// <param name="includeMax">The maximum value is inclusive if true, exclusive if false.</param>
        /// <returns>True if the value is in the range, false otherwise.</returns>
        bool Includes(T value, bool includeMin, bool includeMax);
    }

}
