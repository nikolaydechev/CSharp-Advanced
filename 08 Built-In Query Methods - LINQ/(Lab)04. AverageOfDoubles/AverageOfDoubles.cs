using System;
using System.Linq;

namespace _Lab_04.AverageOfDoubles
{
    public class AverageOfDoubles
    {
        public static void Main()
        {
            var average = Console.ReadLine().Split().Select(double.Parse).Average();
            
            Console.WriteLine($"{average:F2}");
        }
    }
}
