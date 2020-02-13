using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var oddOrEven = Console.ReadLine();

            long minNumber = input.Min();
            long maxNumber = input.Max();

            var numbers = new List<long>();

            for (long i = minNumber; i <= maxNumber; i++)
            {
                numbers.Add(i);
            }

            Predicate<long> odd = x => x % 2 != 0;
            Predicate<long> even = x => x % 2 == 0;

            numbers = oddOrEven == "odd" ? numbers.FindAll(odd) : numbers.FindAll(even);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
