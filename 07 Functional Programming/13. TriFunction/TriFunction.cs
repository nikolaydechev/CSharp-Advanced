using System;
using System.Linq;

namespace _13.TriFunction
{
    public class TriFunction
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<string, int, bool> func = (x, y) => x.Select(z => (int)z).ToArray().Sum() >= y;

            string name = FilteringNames(names, func, N);

            Console.WriteLine(name);
        }

        private static string FilteringNames(string[] names, Func<string, int, bool> func, int N)
        {
            string name = names.FirstOrDefault(x => func(x, N));

            return name;
        }
    }
}
