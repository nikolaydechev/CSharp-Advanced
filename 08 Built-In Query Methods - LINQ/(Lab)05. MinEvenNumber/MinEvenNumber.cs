using System;
using System.Linq;

namespace _Lab_05.MinEvenNumber
{
    public class MinEvenNumber
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList()
                .Where(n => n % 2 == 0)
                .ToList();

            var number = numbers.Count > 0 ? numbers.Min() : 0;
            
            Console.WriteLine(numbers.Count > 0 ? $"{number:F2}" : $"No match");
        }
    }
}
