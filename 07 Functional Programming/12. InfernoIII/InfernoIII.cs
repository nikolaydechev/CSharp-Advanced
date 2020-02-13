using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    public class InfernoIII
    {
        public static void Main()
        {
            var gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            gems.Insert(0, 0);
            gems.Add(0);

            var commandHistory = new List<string>();
            var input = Console.ReadLine();

            CommandHistory(input, commandHistory);
            var indexesToRemove = new List<int>();

            foreach (var command in commandHistory)
            {
                string[] commandParams = command.Split(';');
                var filterType = commandParams[0];
                var filterParam = int.Parse(commandParams[1]);

                Func<int, int, bool> func = (x, y) => x + y == filterParam;
                Func<int, int, int, bool> func1 = (x, y, z) => x + y + z == filterParam;

                switch (filterType)
                {
                    case "Sum Left":
                        indexesToRemove = SumLeftOperation(gems, indexesToRemove, func);
                        break;
                    case "Sum Right":
                        indexesToRemove = SumRightOperation(gems, indexesToRemove, func);
                        break;
                    case "Sum Left Right":
                        indexesToRemove = SumLeftRightOperation(gems, indexesToRemove, func1);
                        break;
                }
            }

            gems.RemoveAt(0);
            gems.RemoveAt(gems.Count - 1);

            foreach (var index in indexesToRemove)
            {
                gems[index - 1] = 1111111111;
            }

            if (gems.Count > 0)
            {
                Console.WriteLine(string.Join(" ", gems.Where(x => x != 1111111111)));
            }
        }

        private static List<int> SumLeftRightOperation(List<int> gems, List<int> result, Func<int, int, int, bool> func1)
        {
            for (int i = 1; i < gems.Count - 1; i++)
            {
                if (func1((gems[i - 1]), gems[i], (gems[i + 1])))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static List<int> SumRightOperation(List<int> gems, List<int> result, Func<int, int, bool> func)
        {
            for (int i = 1; i < gems.Count - 1; i++)
            {
                if (func(gems[i], (gems[i + 1])))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static List<int> SumLeftOperation(List<int> gems, List<int> result, Func<int, int, bool> func)
        {

            for (int i = 1; i < gems.Count - 1; i++)
            {
                if (func((gems[i - 1]), gems[i]))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static void CommandHistory(string input, List<string> commandHistory)
        {
            while (input != "Forge")
            {
                string[] inputParams = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = inputParams[0];
                var filterType = inputParams[1];
                var filterParameter = inputParams[2];

                switch (command)
                {
                    case "Exclude":
                        commandHistory.Add($"{filterType};{filterParameter}");
                        break;
                    case "Reverse":
                        commandHistory.Remove($"{filterType};{filterParameter}");
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
