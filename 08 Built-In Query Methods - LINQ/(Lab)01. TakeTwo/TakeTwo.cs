using System;
using System.Linq;

namespace _Lab_01.TakeTwo
{
    public class TakeTwo
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            numbers
                .Where(x => x >= 10 && x <= 20)
                .Distinct()
                .Take(2)
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}
