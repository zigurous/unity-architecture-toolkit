namespace Zigurous.Architecture
{
    /// <summary>
    /// A generic interface for a range of number values.
    /// </summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    public interface INumberRange<T> : IRange<T>
    {
        /// <summary>
        /// The difference between the maximum and minimum values (Read only).
        /// </summary>
        T Delta { get; }

        /// <summary>
        /// The median value of the range (Read only).
        /// </summary>
        T Median { get; }

        /// <summary>
        /// Returns a random value in the range.
        /// </summary>
        /// <returns>A random value in the range.</returns>
        T Random();

        /// <summary>
        /// Clamps a value to the range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value.</returns>
        T Clamp(T value);

        /// <summary>
        /// Linearly interpolates between the range by <paramref name="t"/>.
        /// </summary>
        /// <param name="t">The interpolant value between [0..1].</param>
        /// <returns>The interpolated value.</returns>
        T Lerp(float t);

        /// <summary>
        /// Calculates the linear parameter t that produces the interpolant
        /// value within the range.
        /// </summary>
        /// <param name="value">The value within the range you want to calculate.</param>
        /// <returns>The interpolant value between [0..1].</returns>
        float InverseLerp(T value);
    }

}
