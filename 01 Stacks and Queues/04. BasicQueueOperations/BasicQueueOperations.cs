using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    public class BasisQueueOperations
    {
        public static void Main()
        {
            Queue<long> queueNumbers = new Queue<long>();

            int[] elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var elementsCountToAdd = elements[0];
            var elementsCountToRemove = elements[1];
            var elementToCheck = elements[2];

            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < elementsCountToAdd; i++)
            {
                queueNumbers.Enqueue(numbers[i]);
            }
            for (int i = 0; i < elementsCountToRemove; i++)
            {
                queueNumbers.Dequeue();
            }

            bool isNumberPresent = queueNumbers.Contains(elementToCheck);

            if (isNumberPresent)
            {
                Console.WriteLine("true");
            }else if(queueNumbers.Count > 0)
            {
                Console.WriteLine(queueNumbers.Min());
            }else
            {
                Console.WriteLine(0);
            }
        }
    }
}
