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
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + hash1;
                hash = hash * 23 + hash2;
                return hash;
            }
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
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + hash1;
                hash = hash * 23 + hash2;
                hash = hash * 23 + hash3;
                return hash;
            }
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
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + hash1;
                hash = hash * 23 + hash2;
                hash = hash * 23 + hash3;
                hash = hash * 23 + hash4;
                return hash;
            }
        }

    }

}
