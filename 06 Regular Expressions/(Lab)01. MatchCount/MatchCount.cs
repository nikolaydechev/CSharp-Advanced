using System;
using System.Text.RegularExpressions;

namespace _Lab_01.MatchCount
{
    public class MatchCount
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            var count = new Regex(word).Matches(text).Count;

            Console.WriteLine(count);
        }
    }
}
