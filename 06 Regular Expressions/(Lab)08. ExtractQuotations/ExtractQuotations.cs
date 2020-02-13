using System;
using System.Text.RegularExpressions;

namespace _Lab_08.ExtractQuotations
{
    public class ExtractQuotations
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"([""'])(.*?)\1").Matches(input);  // ([""'])(?:(?=(\\?))\2.)*?\1

            foreach (Match match in regex)
            {
                Console.WriteLine(match.Groups[2]);
            }
        }
    }
}
