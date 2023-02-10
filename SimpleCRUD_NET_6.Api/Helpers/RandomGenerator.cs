using System;
using System.Linq;

namespace SimpleCRUD.Api.Helpers
{
    public static class RandomGenerator
    {
        private static Random random = new Random();

        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";

            return new string(Enumerable.Repeat(chars,length).Select(c => c[random.Next(c.Length)]).ToArray());
        }

    }
}
