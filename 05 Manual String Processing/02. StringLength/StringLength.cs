using System;

namespace _02.StringLength
{
    class StringLength
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var result = input.Length >= 20 ? input.Substring(0, 20) : input.PadRight(20, '*');

            Console.WriteLine(result);
        }
    }
}
