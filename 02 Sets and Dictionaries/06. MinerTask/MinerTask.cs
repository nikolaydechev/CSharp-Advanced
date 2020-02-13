using System;
using System.Collections.Generic;

namespace _06.MinerTask
{
    public class MinerTask
    {
        public static void Main()
        {
            var resources = new Dictionary<string, int>();
            var input = Console.ReadLine();
            var savedName = "";
            var count = 1;

            while (input != "stop")
            {
                if (count % 2 != 0)
                {
                    if (!resources.ContainsKey(input))
                    {
                        resources.Add(input, 0);
                        savedName = input;
                    }
                    else
                    {
                        savedName = input;
                    }
                }
                else
                {
                    resources[savedName] += int.Parse(input);
                }

                count++;
                input = Console.ReadLine();
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
