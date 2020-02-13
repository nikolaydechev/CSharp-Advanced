using System;

namespace _12.CharacterMultiplier
{
    class CharacterMultiplier
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');

            var firstString = input[0];
            var secondString = input[1];
            var restOfLongerString = "";
            var sumOfAsciiCodes = 0;

            if (firstString.Length < secondString.Length)
            {
                restOfLongerString = secondString.Substring(firstString.Length);
                secondString = secondString.Substring(0, firstString.Length);

            }
            else if (firstString.Length > secondString.Length)
            {
                restOfLongerString = firstString.Substring(secondString.Length);
                firstString = firstString.Substring(0, secondString.Length);
            }

            for (int i = 0; i < firstString.Length; i++)
            {
                var firstChar = (int)firstString[i];
                var secondChar = (int)secondString[i];
                sumOfAsciiCodes += firstChar * secondChar;
            }

            for (int i = 0; i < restOfLongerString.Length; i++)
            {
                sumOfAsciiCodes += (int)restOfLongerString[i];
            }

            Console.WriteLine(sumOfAsciiCodes);
        }
    }
}
