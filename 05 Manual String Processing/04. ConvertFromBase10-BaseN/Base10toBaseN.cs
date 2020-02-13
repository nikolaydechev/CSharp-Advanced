using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _04.ConvertFromBase10_BaseN
{
    class Base10toBaseN
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').ToArray();

            var remStack = new List<string>();

            var baseN = BigInteger.Parse(numbers[0]);
            var decimalNumber = BigInteger.Parse(numbers[1]);

            while (decimalNumber > 0)
            {
                var remainder = decimalNumber % baseN;
                remStack.Add(remainder.ToString());
                decimalNumber = decimalNumber / baseN;
            }

            for (int i = remStack.Count - 1; i >= 0; i--)
            {
                Console.Write(remStack[i]);
            }
            Console.WriteLine();
        }
    }
}
