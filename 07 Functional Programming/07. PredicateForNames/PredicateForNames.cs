using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    public static class Functions
    {
        public static List<string> CheckNamesLength(List<string> collectionNames, Func<string, bool> func, int wordLength)
        {
            List<string> result = new List<string>();

            foreach (var name in collectionNames)
            {
                if (func(name) == false)
                {
                    continue;
                }
                result.Add(name);
            }

            return result;
        }

        public static void Print(List<string> filteredCollectionNames, Action<List<string>> act)
        {
            act(filteredCollectionNames);
        }
    }

    public class PredicateForNames
    {
        public static void Main()
        {
            var wordLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(' ').ToList();

            names = Functions.CheckNamesLength(names, x => x.Length <= wordLength, wordLength);

            Functions.Print(names, x => Console.WriteLine(string.Join("\n", x)));
        }
    }
}
