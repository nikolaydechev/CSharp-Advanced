using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int> func = nums => nums.Min();

            int result = func(numbers);

            Console.WriteLine(result);
        }
    }
}
