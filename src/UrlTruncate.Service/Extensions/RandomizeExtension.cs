using System;
using System.Linq;

namespace UrlTruncate.Service.Extensions
{
    public static class RandomizeExtensions
    {
        const string Alphabet = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static char[] chars = Alphabet.ToCharArray();

        private static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public static string GenerateRandomString(int letters)
        {
            new Random().Shuffle(chars);

            return new string(chars.Take(letters).ToArray());
        }
    }
}