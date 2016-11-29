using System;
using System.Linq;

namespace UrlTruncate.Service.Extensions
{
    /// <summary>
    /// An extention to create a random string within 
    /// </summary>
    public static class RandomizeExtensions
    {
        const string Alphabet = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static char[] chars = Alphabet.ToCharArray();

        /// <summary>
        /// Shuffle randomize algorythm
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <param name="rng">radomize instance</param>
        /// <param name="array">an array of T objects</param>
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

        /// <summary>
        /// Random string
        /// </summary>
        /// <param name="letters">string lenght</param>
        /// <returns>Random string within specified lenght</returns>
        public static string GenerateRandomString(int letters)
        {
            new Random().Shuffle(chars);

            return new string(chars.Take(letters).ToArray());
        }
    }
}