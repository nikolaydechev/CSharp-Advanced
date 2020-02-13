using System;

namespace _01.ActionPrint
{
    class ActionPrint
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split(' ');

            Action<string[]> action = Print;

            action(names);
        }

        private static void Print(string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
