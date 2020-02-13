using System;

namespace _01.ReverseString
{
    class ReverseString
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            input = Reverse(input);
            Console.WriteLine(input);
        }

        private static string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
