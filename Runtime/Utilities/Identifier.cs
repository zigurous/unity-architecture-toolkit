using System;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Generates identifiers.
    /// </summary>
    public static class Identifier
    {
        /// <summary>
        /// Generates a GUID string in a format similar to the following
        /// "0f8fad5b-d9cb-469f-a165-70867728950e".
        /// </summary>
        /// <returns>The generated GUID.</returns>
        public static string Guid()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates a serial number of the specified length in a format
        /// similar to the following "4935E22CD7854C15".
        /// </summary>
        /// <param name="length">The length of the serial number</param>
        /// <returns>The generated serial number.</returns>
        public static string SerialNumber(int length)
        {
            return System.Guid.NewGuid().ToString("N").Substring(0, length).ToUpper();
        }

        /// <summary>
        /// Creates an identifier based on unix time. Since time is always
        /// increasing, this value will be different than generations made in
        /// previous cycles.
        /// </summary>
        /// <remarks>
        /// This should not be used to guarantee uniqueness since ids generated
        /// within the same cycle will usually be identical.
        /// </remarks>
        /// <returns>The generated identifier.</returns>
        public static long UnixTime()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

    }

}
