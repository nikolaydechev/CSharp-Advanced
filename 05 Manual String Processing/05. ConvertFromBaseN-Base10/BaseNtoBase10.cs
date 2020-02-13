using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _05.ConvertFromBaseN_Base10
{
    class BaseNtoBase10
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().ToArray();

            var baseN = BigInteger.Parse(numbers[0]);
            var number = BigInteger.Parse(numbers[1]);

            BigInteger totalSum = baseNtoBase10(baseN, ref number);
            Console.WriteLine(totalSum);

        }

        private static BigInteger baseNtoBase10(BigInteger baseN, ref BigInteger number)
        {
            var digitsOfNumber = new List<string>();
            while (number > 0)
            {
                var digit = number % 10;
                digitsOfNumber.Add(digit.ToString());
                number = number / 10;
            }

            BigInteger totalSum = 0;

            for (int i = 0; i < digitsOfNumber.Count; i++)
            {
                var num = BigInteger.Parse(digitsOfNumber[i]) * BigInteger.Pow(baseN, i);
                totalSum += num;
            }

            return totalSum;
        }
    }
}

