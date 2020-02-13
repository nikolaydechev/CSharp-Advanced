using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PopulationCounter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            var populationData = new Dictionary<string, Dictionary<string, long>>();
            var input = Console.ReadLine();

            while (input != "report")
            {
                string[] inputParams = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var city = inputParams[0];
                var country = inputParams[1];
                var cityPopulation = int.Parse(inputParams[2]);

                if (populationData.ContainsKey(country))
                {
                    if (!populationData[country].ContainsKey(city))
                    {
                        populationData[country].Add(city, cityPopulation);
                    }
                }

                if (!populationData.ContainsKey(country))
                {
                    populationData[country] = new Dictionary<string, long>() { { city, cityPopulation } };
                }
                
                input = Console.ReadLine();
            }

            foreach (var country in populationData.OrderByDescending(p => p.Value.Values.Sum(c => c)))
            {
                var totalPopulation = populationData[country.Key].Values.Sum();
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
