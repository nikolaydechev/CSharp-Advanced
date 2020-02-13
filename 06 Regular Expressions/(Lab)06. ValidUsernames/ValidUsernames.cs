using System;
using System.Text.RegularExpressions;

namespace _Lab_06.ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                var regex = new Regex(@"^[A-Za-z0-9-_]{3,16}$").Matches(input);

                Console.WriteLine(regex.Count > 0 ? "valid" : "invalid");

                input = Console.ReadLine();
            }
        }
    }
}
