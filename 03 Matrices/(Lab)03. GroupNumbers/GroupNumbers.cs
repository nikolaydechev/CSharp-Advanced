using System;
using System.Collections.Generic;
using System.Linq;

namespace _Lab_03.GroupNumbers
{
    class GroupNumbers
    {
        static void Main()
        {
            var numbers =
                Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            List<List<int>> result = new List<List<int>>()
            {
                new List<int>(),
                new List<int>(),
                new List<int>()
            };

            foreach (var number in numbers)
            {
                if (Math.Abs(number) % 3 == 0)
                {
                    result[0].Add(number);
                }
                else if (Math.Abs(number) % 3 == 1)
                {
                    result[1].Add(number);
                }
                else if(Math.Abs(number) % 3 == 2)
                {
                    result[2].Add(number);
                }
            }

            //result[0] = numbers.Where(n => Math.Abs(n) % 3 == 0).ToList();
            //result[1] = numbers.Where(n => Math.Abs(n) % 3 == 1).ToList();
            //result[2] = numbers.Where(n => Math.Abs(n) % 3 == 2).ToList();
            Console.WriteLine(string.Join(" ", result[0]));
            Console.WriteLine(string.Join(" ", result[1]));
            Console.WriteLine(string.Join(" ", result[2]));


            //SHORTER SOLUTION:

            //var zero = numbers.Where(n => Math.Abs(n) % 3 == 0);
            //var one = numbers.Where(n => Math.Abs(n) % 3 == 1);
            //var two = numbers.Where(n => Math.Abs(n) % 3 == 2);
            //Console.WriteLine(string.Join(" ", zero));
            //Console.WriteLine(string.Join(" ", one));
            //Console.WriteLine(string.Join(" ", two));
        }
    }
}

