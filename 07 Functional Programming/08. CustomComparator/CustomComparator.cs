using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    public static class Functions
    {
        public static List<int> ArraySort(List<int> collectionNumbers, Func<int, bool> func)
        {
            List<int> result = new List<int>();

            foreach (var number in collectionNumbers)
            {
                if (func(number) == true)
                {
                    result.Add(number);
                }
            }

            result.Sort();

            return result;
        }

        public static void Print(List<int> collectionNumbers, Action<List<int>> act)
        {
            act(collectionNumbers);
        }
    }

    public class CustomComparator
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            evenNumbers = Functions.ArraySort(numbers, n => n % 2 == 0);
            oddNumbers = Functions.ArraySort(numbers, n => n % 2 != 0);

            evenNumbers.AddRange(oddNumbers);

            Functions.Print(evenNumbers, x => Console.WriteLine(string.Join(" ", x)));
        }
    }
}
