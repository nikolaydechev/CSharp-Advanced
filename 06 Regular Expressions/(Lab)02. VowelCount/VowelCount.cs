using System;
using System.Text.RegularExpressions;

namespace _Lab_02.VowelCount
{
    public class VowelCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var vowelsCount = new Regex("[AEIOUYaeiouy]").Matches(text).Count;

            Console.WriteLine($"Vowels: {vowelsCount}");
        }
    }
}
