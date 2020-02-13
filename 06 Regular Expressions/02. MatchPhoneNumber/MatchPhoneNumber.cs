using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var regex = new Regex(@"^(\+359)(\s|\-)(2)\2[0-9]{3}\2[0-9]{4}$").IsMatch(input);

                if (regex)
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
