using System;
using System.Linq;

namespace _Lab_02.SumNumbers
{
    public class SumNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> func = nums => nums.Length;
            Func<int[], int> func1 = nums => nums.Sum();

            Console.WriteLine(func(numbers));
            Console.WriteLine(func1(numbers));
        }
    }
}
