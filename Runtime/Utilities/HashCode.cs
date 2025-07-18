namespace Zigurous.Architecture
{
    /// <summary>
    /// Combines multiple hash codes into a single value.
    /// </summary>
    public static class HashCode
    {
        /// <summary>
        /// Combines two hash codes into one unique hash.
        /// </summary>
        /// <param name="hash1">The first hash.</param>
        /// <param name="hash2">The second hash.</param>
        /// <returns>The combined hash code.</returns>
        public static int Combine(int hash1, int hash2)
        {
            return System.HashCode.Combine(hash1, hash2);
        }

        /// <summary>
        /// Combines three hash codes into one unique hash.
        /// </summary>
        /// <param name="hash1">The first hash.</param>
        /// <param name="hash2">The second hash.</param>
        /// <param name="hash3">The third hash.</param>
        /// <returns>The combined hash code.</returns>
        public static int Combine(int hash1, int hash2, int hash3)
        {
            return System.HashCode.Combine(hash1, hash2, hash3);
        }

        /// <summary>
        /// Combines four hash codes into one unique hash.
        /// </summary>
        /// <param name="hash1">The first hash.</param>
        /// <param name="hash2">The second hash.</param>
        /// <param name="hash3">The third hash.</param>
        /// <param name="hash4">The fourth hash.</param>
        /// <returns>The combined hash code.</returns>
        public static int Combine(int hash1, int hash2, int hash3, int hash4)
        {
            return System.HashCode.Combine(hash1, hash2, hash3, hash4);
        }

        /// <summary>
        /// Generates a random seed by combining the current time into a hash code.
        /// </summary>
        /// <returns>A random seed as an integer.</returns>
        public static int RandomSeed()
        {
            System.DateTime now = System.DateTime.UtcNow;
            return Combine(now.Hour, now.Minute, now.Second, now.Millisecond);
        }

        /// <summary>
        /// Generates a random seed by combining the current time into a hash
        /// code and converting it to an unsigned integer.
        /// </summary>
        /// <returns>A random seed as an unsigned integer.</returns>
        public static uint RandomUnsignedSeed()
        {
            long lseed = System.Convert.ToInt64(RandomSeed());
            return unchecked(System.Convert.ToUInt32(lseed + int.MaxValue));
        }

    }

}
