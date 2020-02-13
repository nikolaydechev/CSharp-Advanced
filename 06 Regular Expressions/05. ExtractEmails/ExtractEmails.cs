using System;
using System.Text.RegularExpressions;

namespace _05.ExtractEmails
{
    public class ExtractEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"(?:\s|^)(?:[A-Za-z0-9]+[\-\._])*[A-Za-z0-9]+\@[A-Za-z-]+[\-]*[A-Za-z-]+(?:\.[A-Za-z]+)+").Matches(input);

            foreach (Match match in regex)
            {
                Console.WriteLine(match.Value.Trim());
            }
        }
    }
}
