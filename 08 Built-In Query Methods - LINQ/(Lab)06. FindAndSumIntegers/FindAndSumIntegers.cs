using System;
using System.Linq;

namespace _Lab_06.FindAndSumIntegers
{
    public class FindAndSumIntegers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(n =>
                {
                    long value;
                    bool success = long.TryParse(n, out value);
                    return new {value, success};
                })
                .Where(x => x.success)
                .Select(x => x.value)
                .ToList();

            Console.WriteLine(input.Count > 0 ? $"{input.Sum()}" : "No match");

        }
    }
}
