using System.Text.RegularExpressions;

namespace _Lab_07.ValidTime
{
    using System;

    public class ValidTime
    {
        public static void Main()
        {
            var input = Console.ReadLine();


            while (input != "END")
            {
                var regex = new Regex(@"^[0-1][0-9]\:[0-5][0-9]\:[0-5][0-9]\s(AM|PM)$").IsMatch(input);

                Console.WriteLine(regex ? "valid" : "invalid");

                input = Console.ReadLine();
            }
        }
    }
}
