using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates_2nd_variant_
{
    public static class Predicates
    {
        public static List<Func<int, bool>> predicates = new List<Func<int, bool>>();

        public static void AddPredicate(Func<int, bool> predicate)
        {
            predicates.Add(predicate);
        }

        public static List<int> ApplyPredicates(List<int> numbers)
        {
            List<int> result = new List<int>();

            bool divisibleToAll = true;

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];

                foreach (var predicate in predicates)
                {
                    if (!predicate(currentNum))
                    {
                        divisibleToAll = false;
                        break;
                    }
                }

                if (divisibleToAll)
                {
                    result.Add(currentNum);
                }
                divisibleToAll = true;
            }
            
            return result;
        }
    }

    public class ListPredicates
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

            foreach (var divisor in divisors)
            {
                Predicates.AddPredicate(x => x % divisor == 0);
            }

            numbers = Predicates.ApplyPredicates(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
