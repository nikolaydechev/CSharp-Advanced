using System;
using System.Linq;

namespace _Lab_02.UpperStrings
{
    public class UpperStrings
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();

            words
                .Select(x => x.ToUpper())
                .ToList()
                .ForEach(w => Console.Write(w + " "));
        }
    }
}
