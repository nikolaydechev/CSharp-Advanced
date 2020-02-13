using System;
using System.Text.RegularExpressions;

namespace _Lab_03.NonDigitCount
{
    public class NonDigitCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var count = new Regex("[^^0123456789]").Matches(text).Count;

            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
