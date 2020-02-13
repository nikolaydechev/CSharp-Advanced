using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.OlympicsAreComing
{
    public class OlympicsAreComing
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var data = new Dictionary<string, Dictionary<string, int>>();

            while (input != "report")
            {
                //var regex = new Regex(@"([A-Za-z]*\s*[A-Za-z]+)\s*\|\s*([A-Za-z]*\s*[A-Za-z]+)\s*").Match(input);
                //var athlete = Regex.Replace(regex.Groups[1].Value, @"\s{2,}", " ").Trim();
                //var country = regex.Groups[2].Value.Trim();

                string[] inputParams = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var athlete = Regex.Replace(inputParams[0], @"\s{2,}", " ").Trim();
                var country = Regex.Replace(inputParams[1], @"\s{2,}", " ").Trim();

                if (!data.ContainsKey(country))
                {
                    data[country] = new Dictionary<string, int>();
                }
                if (!data[country].ContainsKey(athlete))
                {
                    data[country].Add(athlete, 0);
                }
                data[country][athlete] += 1;

                input = Console.ReadLine();
            }
            
            
            foreach (var country in data.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.Write($"{country.Key} ");

                Console.WriteLine($"({country.Value.Count} participants): {country.Value.Values.Sum()} wins");
            }
        }
    }
}
