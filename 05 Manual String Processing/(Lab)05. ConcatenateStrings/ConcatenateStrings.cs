using System;
using System.Text;

namespace _Lab_05.ConcatenateStrings
{
    public class ConcatenateStrings
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                result.Append($"{word} ");
            }

            Console.WriteLine(result);
        }
    }
}
