using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    public class MaximumElement
    {
        public static void Main()
        {
            var stack = new Stack<ulong>();
            ulong maxElement = 0;
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var inputNumbers = Console.ReadLine().Split().Select(ulong.Parse).ToArray();
                var queryType = inputNumbers[0];

                switch (queryType)
                {
                    case 1:
                        stack.Push(inputNumbers[1]);
                        maxElement = Math.Max(inputNumbers[1], maxElement);
                        break;

                    case 2:
                        ulong element = stack.Pop();
                        if (element == maxElement && stack.Count > 0)
                        {
                            maxElement = stack.Max();
                        }
                        else if (stack.Count == 0)
                        {
                            maxElement = 0;
                        }
                        break;

                    case 3:
                        Console.WriteLine(maxElement);
                        break;
                }
            }
        }
    }
}
