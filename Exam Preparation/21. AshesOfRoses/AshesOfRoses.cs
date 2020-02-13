using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _21.AshesOfRoses
{
    public class AshesOfRoses
    {
        public static void Main()
        {
            var dataFlowers = new Dictionary<string, Dictionary<string, long>>();
            var pattern = @"^Grow <([A-Z]{1}[a-z]+)> <([A-Za-z0-9]+)> (\d+)$";
            var input = Console.ReadLine();

            while (input != "Icarus, Ignite!")
            {
                var regex = new Regex(pattern).Match(input);
                if (regex.Success)
                {
                    var regionName = regex.Groups[1].Value;
                    var colorName = regex.Groups[2].Value;
                    var roseAmount = long.Parse(regex.Groups[3].Value);

                    if (!dataFlowers.ContainsKey(regionName))
                    {
                        dataFlowers[regionName] = new Dictionary<string, long>();
                    }
                    if (!dataFlowers[regionName].ContainsKey(colorName))
                    {
                        dataFlowers[regionName][colorName] = 0;
                    }
                    dataFlowers[regionName][colorName] += roseAmount;
                }

                input = Console.ReadLine();
            }

            var orderedRoses = dataFlowers
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key);

            foreach (var kvp in orderedRoses)
            {
                Console.WriteLine(kvp.Key);

                foreach (var color in kvp.Value.OrderBy(x => x.Value).ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }
        }
    }
}
