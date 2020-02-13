using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    public static class Functions
    {
        public static List<int> RemovesNumbersDivisibleByNum(List<int> collection, Func<int, bool> func)
        {
            List<int> result = new List<int>();

            foreach (var number in collection)
            {
                if (func(number) == false)
                {
                    result.Add(number);
                }
            }

            return result;
        }

        public static void Print(List<int> collection, Action<List<int>> act)
        {
            act(collection);
        }
    }

    public class ReverseAndExclude
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var n = int.Parse(Console.ReadLine());

            numbers.Reverse();

            numbers = Functions.RemovesNumbersDivisibleByNum(numbers, num => num % n == 0);

            Functions.Print(numbers, x => Console.WriteLine(string.Join(" ", x)));
        }
    }
}
