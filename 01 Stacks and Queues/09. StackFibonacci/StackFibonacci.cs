using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    public class StackFibonacci
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 2; i <= number; i++)
            {
                var currentNumber = stack.Pop();
                var nextNumber = currentNumber + stack.Peek();
                stack.Push(currentNumber);
                stack.Push(nextNumber);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
