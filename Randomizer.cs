using System;

namespace RouletteGame.Legacy
{
    class Randomizer : IRandomizer
    {
        public uint Next()
        {
            var n = (uint)new Random().Next(0, 37);
            return n;
        }
    }
}