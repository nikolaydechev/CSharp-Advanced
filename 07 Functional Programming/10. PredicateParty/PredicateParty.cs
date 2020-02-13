using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    public static class Functions
    {
        public static List<string> RemoveNames(List<string> collectionNames, Func<string, bool> func)
        {
            List<string> result = new List<string>();
            result = collectionNames.ToList();

            foreach (var name in collectionNames)
            {
                if (func(name))
                {
                    result.Remove(name);
                }
            }

            return result;
        }

        public static List<string> DoubleNames(List<string> collectionNames, Func<string, bool> func)
        {
            List<string> result = new List<string>();
            result = collectionNames.ToList();

            foreach (var name in collectionNames)
            {
                if (func(name))
                {
                    int index = collectionNames.IndexOf(name);
                    result.Insert(index, name);
                }
            }

            return result;
        }
    }

    public class PredicateParty
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();

            var input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] inputParams = input.Split(' ');
                string command = inputParams[0];
                string criteria = inputParams[1];
                string givenString = inputParams[2];

                Func<string, bool> func = s => s.StartsWith(givenString);
                Func<string, bool> func1 = s => s.EndsWith(givenString);
                Func<string, bool> func2 = s => s.Length == int.Parse(givenString);

                switch (command)
                {
                    case "Remove":
                        switch (criteria)
                        {
                            case "StartsWith":
                                names = Functions.RemoveNames(names, func);
                                break;
                            case "EndsWith":
                                names = Functions.RemoveNames(names, func1);
                                break;
                            case "Length":
                                names = Functions.RemoveNames(names, func2);
                                break;
                        }
                        break;

                    case "Double":
                        switch (criteria)
                        {
                            case "StartsWith":
                                names = Functions.DoubleNames(names, func);
                                break;
                            case "EndsWith":
                                names = Functions.DoubleNames(names, func1);
                                break;
                            case "Length":
                                names = Functions.DoubleNames(names, func2);
                                break;
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            if (names.Count >= 1)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
