using System;
using System.Collections.Generic;
using System.Linq;

namespace _Lab_03.CountSameValuesInArray
{
    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var countNumbersTime = new SortedDictionary<double, int>();

            var numbers = 
                    Console.ReadLine()
                        .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToArray();

            foreach (var number in numbers)
            {
                if (!countNumbersTime.ContainsKey(number))
                {
                    countNumbersTime[number] = 0;
                }

                countNumbersTime[number]++;
            }

            string numbersCounts = string.Join("\n", countNumbersTime.Select(x => x.Key + " - " + x.Value + " times"));

            Console.WriteLine(numbersCounts);
        }
    }
}
