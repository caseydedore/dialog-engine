using System;

namespace DialogEngineTests.Data
{
    public class NumberGenerator
    {
        private Random random = new Random();

        public int GetRandomInt(int min = int.MinValue, int max = int.MaxValue)
        {
            return random.Next(min, max);
        }
    }
}
