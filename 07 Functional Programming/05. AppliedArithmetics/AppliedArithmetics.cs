using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var input = Console.ReadLine();
            
            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        Func<List<int>, List<int>> func = nums => nums.Select(n => n + 1).ToList();
                        numbers = func(numbers);
                        break;

                    case "multiply":
                        Func<List<int>, List<int>> func1 = nums => nums.Select(n => n * 2).ToList();
                        numbers = func1(numbers);
                        break;

                    case "subtract":
                        Func<List<int>, List<int>> func2 = nums => nums.Select(n => n - 1).ToList();
                        numbers = func2(numbers);
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
