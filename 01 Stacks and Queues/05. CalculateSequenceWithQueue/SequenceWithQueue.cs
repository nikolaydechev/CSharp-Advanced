using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    public class BasicQueueOperations
    {
        public static void Main()
        {
            var queue = new Queue<long>();
            var result = new List<long>();
            var number = long.Parse(Console.ReadLine());

            result.Add(number);
            queue.Enqueue(number);

            while (result.Count < 50)
            {
                var currentElement = queue.Dequeue();
                var firstNumber = currentElement + 1;
                var secondNumber = currentElement * 2 + 1;
                var thirdNumber = currentElement + 2;

                queue.Enqueue(firstNumber);
                queue.Enqueue(secondNumber);
                queue.Enqueue(thirdNumber);

                result.Add(firstNumber);
                result.Add(secondNumber);
                result.Add(thirdNumber);
            }
            
            Console.WriteLine(string.Join(" ", result.Take(50)));
        }
    }
}
