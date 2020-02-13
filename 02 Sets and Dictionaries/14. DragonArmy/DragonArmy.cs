using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.DragonArmy
{
    public class DragonArmy
    {
        public static void Main()
        {
            var dragonList = new List<Dragon>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var dragonType = input[0];
                var dragonName = input[1];
                double dragonDamage = (input[2] != "null") ? double.Parse(input[2]) : 45;
                double dragonHealth = (input[3] != "null") ? double.Parse(input[3]) : 250;
                double dragonArmor = (input[4] != "null") ? double.Parse(input[4]) : 10;

                if (dragonList.Any(x => x.Type == dragonType))
                {
                    var currentDragon = dragonList.First(x => x.Type == dragonType);
                    if (currentDragon.DragonStats.Name != dragonName)
                    {
                        currentDragon.DragonCount++;
                        currentDragon.TotalDamage += dragonDamage;
                        currentDragon.TotalHealth += dragonHealth;
                        currentDragon.TotalArmor += dragonArmor;
                        currentDragon.DragonStats = new Stats
                        {
                            Name = dragonName,
                            Damage = dragonDamage,
                            Health = dragonHealth,
                            Armor = dragonArmor
                        };
                        currentDragon.DragonStatsList.Add(currentDragon.DragonStats);
                    }
                    else
                    {
                        currentDragon.TotalDamage -= currentDragon.DragonStats.Damage;
                        currentDragon.TotalHealth -= currentDragon.DragonStats.Health;
                        currentDragon.TotalArmor -= currentDragon.DragonStats.Armor;

                        currentDragon.DragonStatsList.Remove(currentDragon.DragonStats);

                        currentDragon.DragonStats.Name = dragonName;
                        currentDragon.DragonStats.Damage = dragonDamage;
                        currentDragon.DragonStats.Health = dragonHealth;
                        currentDragon.DragonStats.Armor = dragonArmor;
                        currentDragon.TotalDamage += dragonDamage;
                        currentDragon.TotalHealth += dragonHealth;
                        currentDragon.TotalArmor += dragonArmor;
                        currentDragon.DragonStatsList.Add(currentDragon.DragonStats);
                    }
                }

                if (dragonList.All(x => x.Type != dragonType))
                {
                    var dragon = new Dragon
                    {
                        Type = dragonType,
                        DragonCount = 1,
                        TotalDamage = dragonDamage,
                        TotalHealth = dragonHealth,
                        TotalArmor = dragonArmor,
                        DragonStats = new Stats
                        {
                            Name = dragonName,
                            Damage = dragonDamage,
                            Health = dragonHealth,
                            Armor = dragonArmor
                        }
                    };

                    dragon.DragonStatsList = new List<Stats> {dragon.DragonStats};

                    dragonList.Add(dragon);
                }
            }

            foreach (Dragon dragon in dragonList)
            {
                var dragonCount = dragon.DragonCount;

                Console.WriteLine($"{dragon.Type}::" +
                                  $"({dragon.TotalDamage / dragonCount:F2}" +
                                  $"/{dragon.TotalHealth / dragonCount:F2}" +
                                  $"/{dragon.TotalArmor / dragonCount:F2})");

                foreach (var item in dragon.DragonStatsList.OrderBy(x=>x.Name))
                {
                    Console.WriteLine($"-{item.Name} ->" +
                                      $" damage: {item.Damage}," +
                                      $" health: {item.Health}, armor: {item.Armor}");
                }
            }
        }
    }
}
