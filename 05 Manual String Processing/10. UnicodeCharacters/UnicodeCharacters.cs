using System;
using System.Linq;

namespace _10.UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var result = input.Select(t => string.Format("u{0:x4}", (int)t)).ToList();

            Console.WriteLine("\\" + string.Join("\\", result));
        }
    }
}
