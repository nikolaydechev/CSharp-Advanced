using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    public class PeriodicTable
    {
        public static void Main()
        {
            SortedSet<string> chemicalElements = new SortedSet<string>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in elements)
                {
                    chemicalElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
