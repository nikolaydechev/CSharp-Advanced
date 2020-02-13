using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    public class BasicStackOperations
    {
        public static void Main()
        {
            int[] elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var elementsCountToPush = elements[0];
            var elementsCountToPop = elements[1];
            var elementToCheck = elements[2];

            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
                elementsCountToPush--;
                if(elementsCountToPush == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < elementsCountToPop; i++)
            {
                stack.Pop();
            }

            bool isNumberPresent = stack.Contains(elementToCheck);

            if (isNumberPresent)
            {
                Console.WriteLine("true");
            }else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }else
            {
                Console.WriteLine(0);
            }
        }
    }
}
