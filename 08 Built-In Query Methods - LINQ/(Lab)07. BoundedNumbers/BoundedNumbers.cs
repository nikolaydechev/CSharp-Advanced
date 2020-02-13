using System;
using System.Linq;

namespace _Lab_07.BoundedNumbers
{
    public class BoundedNumbers
    {
        public static void Main()
        {
            var bounds = Console.ReadLine().Split().Select(int.Parse).ToList();
            var lowerBound = bounds.Min();
            var upperBound = bounds.Max();

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n >= lowerBound && n <= upperBound)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
