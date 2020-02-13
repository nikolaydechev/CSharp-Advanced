namespace _Lab_08.MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MapDistricts
    {
        public static void Main()
        {
            var cities = new Dictionary<string, List<long>>();

            var citiesDistrictsPopulation = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var minimumPopulation = long.Parse(Console.ReadLine());

            foreach (var item in citiesDistrictsPopulation)
            {
                var data = item.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
                var city = data[0];
                var population = long.Parse(data[1].Trim());

                if (!cities.ContainsKey(city))
                {
                    cities[city] = new List<long>();
                }
                cities[city].Add(population);
            }

            var orderedCities = cities
                                .Where(x => x.Value.Sum() > minimumPopulation)
                                .OrderByDescending(x => x.Value.Sum())
                                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var kvp in orderedCities)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(" ", kvp.Value.OrderByDescending(x => x).Take(5))}");
            }
        }
    }
}
