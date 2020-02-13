using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07.ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { '/', '\\', '(', ')', ' ' },StringSplitOptions.RemoveEmptyEntries);

            var validNames = new List<string>();

            var regex = new Regex(@"^[A-Za-z][\w]{2,24}$");

            foreach (var username in input)
            {
                if (regex.IsMatch(username))
                {
                    validNames.Add(username);
                }
            }

            var maxSumOfLengths = 0;
            var firstUser = "";
            var secondUser = "";

            for (int i = 0; i < validNames.Count - 1; i++)
            {
                var sum = validNames[i].Length + validNames[i + 1].Length;

                if (maxSumOfLengths < sum)
                {
                    maxSumOfLengths = sum;
                    firstUser = validNames[i];
                    secondUser = validNames[i + 1];
                }
            }

            Console.WriteLine(firstUser);
            Console.WriteLine(secondUser);
        }
    }
}
