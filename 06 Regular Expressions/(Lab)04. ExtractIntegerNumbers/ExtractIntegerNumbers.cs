using System;
using System.Text.RegularExpressions;

namespace _Lab_04.ExtractIntegerNumbers
{
    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regexMatches = new Regex("[0-9]+").Matches(text); // MatchCollection

            foreach (Match digit in regexMatches)
            {
                Console.WriteLine(digit);
            }
        }
    }
}
