using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.LegendaryFarming
{
    public class LegendaryFarming
    {
        public static void Main()
        {
            var materialsData = new Dictionary<string, int>() { { "fragments", 0 }, { "shards", 0 }, { "motes", 0 } };
            var winningMaterial = "";
            bool hasWinner = false;

            while (true)
            {
                if (hasWinner)
                {
                    break;
                }

                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < input.Length; i += 2)
                {
                    if (!materialsData.ContainsKey(input[i + 1].ToLower()))
                    {
                        materialsData[input[i + 1].ToLower()] = int.Parse(input[i]);
                    }
                    else
                    {
                        materialsData[input[i + 1].ToLower()] += int.Parse(input[i]);
                    }
                    if (materialsData.Take(3).Any(x => x.Value >= 250))
                    {
                        winningMaterial = materialsData.First(x => x.Value >= 250).Key;
                        materialsData[winningMaterial] -= 250;
                        if (materialsData[winningMaterial] < 0)
                        {
                            materialsData[winningMaterial] = 0;
                        }
                        hasWinner = true;
                        break;
                    }
                }
            }

            var winner = "";

            switch (winningMaterial)
            {
                case "shards":
                    winner = "Shadowmourne";
                    break;
                case "fragments":
                    winner = "Valanyr";
                    break;
                default:
                    winner = "Dragonwrath";
                    break;
            }

            Console.WriteLine($"{winner} obtained!");

            foreach (var item in materialsData.Take(3).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in materialsData.Skip(3).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
