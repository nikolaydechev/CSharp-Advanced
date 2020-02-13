using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.DragonArmy_other_solution_
{
    public class DragonArmy
    {
        public static void Main()
        {
            var dragonData = new Dictionary<string, SortedDictionary<string, int[]>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var dragonType = input[0];
                var dragonName = input[1];
                int dragonDamage = (input[2] != "null") ? int.Parse(input[2]) : 45;
                int dragonHealth = (input[3] != "null") ? int.Parse(input[3]) : 250;
                int dragonArmor = (input[4] != "null") ? int.Parse(input[4]) : 10;

                if (dragonData.ContainsKey(dragonType))
                {
                    if (dragonData[dragonType].ContainsKey(dragonName))
                    {
                        dragonData[dragonType][dragonName][0] = dragonDamage;
                        dragonData[dragonType][dragonName][1] = dragonHealth;
                        dragonData[dragonType][dragonName][2] = dragonArmor;
                    }
                    else
                    {
                        dragonData[dragonType].Add(dragonName, new int[3] { dragonDamage, dragonHealth, dragonArmor });
                    }
                }

                if (!dragonData.ContainsKey(dragonType))
                {
                    dragonData[dragonType] = new SortedDictionary<string, int[]>()
                    {
                        {dragonName, new int[3] {dragonDamage,dragonHealth,dragonArmor}  }
                    };
                }
            }

            foreach (var dragon in dragonData)
            {
                Console.WriteLine($"{dragon.Key}::" +
                                  $"({dragon.Value.Select(x => x.Value[0]).Average():F2}" +
                                  $"/{dragon.Value.Select(x => x.Value[1]).Average():F2}" +
                                  $"/{dragon.Value.Select(x => x.Value[2]).Average():F2})");

                foreach (var item in dragon.Value)
                {
                    Console.WriteLine($"-{item.Key} -> " +
                                      $"damage: {item.Value[0]}," +
                                      $" health: {item.Value[1]}," +
                                      $" armor: {item.Value[2]}");
                }
            }
        }
    }
}
