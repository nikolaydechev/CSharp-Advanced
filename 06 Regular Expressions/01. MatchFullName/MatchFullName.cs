using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    public class MatchFullName
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var regex = new Regex(@"[A-Z][a-z]+\s[A-Z][a-z]+").IsMatch(input);

                if (regex)
                {
                    Console.WriteLine(input);
                }
                input = Console.ReadLine();
            }
        }
    }
}
