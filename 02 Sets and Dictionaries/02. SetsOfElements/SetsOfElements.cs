using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            int[] setsLengths = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstSetCount = setsLengths[0];
            var secondSetCount = setsLengths[1];

            for (int i = 0; i < firstSetCount; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < secondSetCount; i++)
            {
                var number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ",firstSet));
            
        }
    }
}
