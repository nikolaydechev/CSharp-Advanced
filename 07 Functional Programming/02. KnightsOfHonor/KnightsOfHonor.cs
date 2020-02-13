using System;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> action = PrintNames;
            action(names);
        }

        private static void PrintNames(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine("Sir {0}", name);
            }
        }
    }
}
