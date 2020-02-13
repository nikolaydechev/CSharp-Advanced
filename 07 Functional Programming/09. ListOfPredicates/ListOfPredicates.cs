using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    public static class Functions
    {
        public static List<int> Predicates(List<int> numbersRange, List<int> collectionNumbers, Func<int, int, bool> func)
        {
            List<int> result = new List<int>();

            bool divisibleToAll = true;

            foreach (var number in numbersRange)
            {
                foreach (var num in collectionNumbers)
                {
                    if (!func(number, num))
                    {
                        divisibleToAll = false;
                        break;
                    }
                }

                if (divisibleToAll)
                {
                    result.Add(number);
                }
                divisibleToAll = true;
            }

            return result;
        }

        public static void Print(List<int> collectionNumbers, Action<List<int>> act)
        {
            act(collectionNumbers);
        }
    }

    public class ListOfPredicates
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<int> divisors = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                numbers.Add(i);
            }

            //Func<int, int, bool> func = DivisibleToAllSequence;

            Func<int, int, bool> func1 = (x, y) => x % y == 0;

            numbers = Functions.Predicates(numbers, divisors, func1);

            Functions.Print(numbers, nums => Console.WriteLine(string.Join(" ", nums)));
        }

        //private static bool DivisibleToAllSequence(int firstNumber, int secondNumber)
        //{
        //    if (firstNumber % secondNumber != 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}
