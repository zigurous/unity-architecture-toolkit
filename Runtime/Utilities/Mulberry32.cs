namespace Zigurous.Architecture
{
    public sealed class Mulberry32
    {
        private uint state;

        public Mulberry32(uint seed)
        {
            state = seed;
        }

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

        public float NextFloat()
        {
            return Next() / (float)uint.MaxValue;
        }

        public double NextDouble()
        {
            return Next() / (double)uint.MaxValue;
        }

    }

}
