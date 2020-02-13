using System;

namespace _08.RecursiveFibonacci
{
    public class RecursiveFibonacci
    {
        private static long[] fibNumbers;

        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            fibNumbers = new long[number];

            var result = GetFibonacci(number);

            Console.WriteLine(result);
        }

        private static long GetFibonacci(long number)
        {
            if (number <= 2)
            {
                return 1;
            }

            if (fibNumbers[number - 1] != 0)
            {
                return fibNumbers[number - 1];
            }

            return fibNumbers[number - 1] = GetFibonacci(number - 1) + GetFibonacci(number - 2);
        }
    }
}
