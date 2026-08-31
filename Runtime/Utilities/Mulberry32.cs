namespace Zigurous.Architecture
{
    /// <summary>
    /// A fast 32-bit seedable pseudo-random number generator.
    /// </summary>
    public sealed class Mulberry32
    {
        private uint state;

        /// <summary>
        /// Creates a new Mulberry32 with the given seed.
        /// </summary>
        /// <param name="seed">The seed of the pseudo-random number generator.</param>
        public Mulberry32(uint seed)
        {
            state = seed;
        }

        /// <summary>
        /// Gets the next value in the pseudo-random number sequence.
        /// </summary>
        /// <returns>The next value in the pseudo-random number sequence.</returns>
        public uint Next()
        {
            unchecked
            {
                state += 0x6D2B79F5;
                uint z = state;
                z = (z ^ (z >> 15)) * (z | 1);
                z ^= z + (z ^ (z >> 7)) * (z | 61);
                return z ^ (z >> 14);
            }
        }

        /// <summary>
        /// Gets the next value in the pseudo-random number sequence as a float.
        /// </summary>
        /// <returns>The next value in the pseudo-random number sequence as a float.</returns>
        public float NextFloat()
        {
            return Next() / (float)uint.MaxValue;
        }

        /// <summary>
        /// Gets the next value in the pseudo-random number sequence as a double.
        /// </summary>
        /// <returns>The next value in the pseudo-random number sequence as a double.</returns>
        public double NextDouble()
        {
            return Next() / (double)uint.MaxValue;
        }

    }

}
