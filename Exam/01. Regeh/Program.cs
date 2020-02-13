using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    public class Program
    {
        public static void Main()
        {
            string pattern = @"[^\s]*\[[^\s]+<(\d+)REGEH(\d+)>[^\s]+";

            var input = Console.ReadLine();

            var numbers = new List<int>();
            var result = new StringBuilder();

            var regex = new Regex(pattern).Matches(input);

            foreach (Match match in regex)
            {
                numbers.Add(int.Parse(match.Groups[1].Value));
                numbers.Add(int.Parse(match.Groups[2].Value));
            }

            var currentIndex = numbers[0];
            for (int i = 0; i < numbers.Count; i++)
            {
                result.Append(input[currentIndex]);
                if (i + 1 < numbers.Count)
                {
                    currentIndex += numbers[i + 1];
                }

                if (currentIndex > input.Length)
                {
                    currentIndex++;
                }
                currentIndex = currentIndex % input.Length;
                if (currentIndex < 0)
                {
                    currentIndex += input.Length;
                }
            }

            Console.WriteLine(result);

            //int debug = 0;
        }
    }
}
