using System;
using System.Collections.Generic;

namespace _Lab_05.FilterByAge
{
    public class FilterByAge
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var list = new Dictionary<string, int>();


            for (int i = 0; i < n; i++)
            {
                var peopleData = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(peopleData[0], int.Parse(peopleData[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var result = new List<string>();

            switch (condition)
            {
                case "older":
                    Func<int, bool> func = x => x >= age;
                    result = Function(list, func, age, format);
                    break;
                case "younger":
                    Func<int, bool> func1 = x => x < age;
                    result = Function(list, func1, age, format);
                    break;
            }

            Print(result, x => Console.WriteLine(string.Join("\n", result)));
        }

        private static void Print(List<string> result, Action<object> action)
        {
            action(result);
        }

        private static List<string> Function(Dictionary<string, int> list, Func<int, bool> func, int age, string format)
        {
            var data = new List<string>();

            foreach (var person in list)
            {
                if (func(person.Value))
                {
                    switch (format)
                    {
                        case "name age":
                            data.Add($"{person.Key} - {person.Value}");
                            break;
                        case "name":
                            data.Add($"{person.Key}");
                            break;
                        case "age":
                            data.Add($"{person.Value}");
                            break;
                    }
                }
            }

            return data;
        }
    }
}
