using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13.СръбскоUnleashed
{
    public class СръбскoUnleashed
    {
        public static void Main()
        {
            var singersData = new Dictionary<string, Dictionary<string, long>>();
            string inputPatterns =
                @"([A-Za-z]+\s?[A-Za-z]+\s?[A-Za-z]+\s)@([A-Za-z]+\s?[A-Za-z]+\s?[A-Za-z]+\s)(\d+)\s(\d+)";

            Regex regex = new Regex(inputPatterns);

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string[] inputTokens = input.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                var singer = inputTokens[0].Trim();

                string[] restOfTokens = inputTokens[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var ticketPrice = int.Parse(restOfTokens[restOfTokens.Length - 2]);
                var ticketsCount = int.Parse(restOfTokens[restOfTokens.Length - 1]);
                var venue = "";

                for (int i = 0; i < restOfTokens.Length - 2; i++)
                {
                    venue += restOfTokens[i] + " ";
                }
                venue = venue.Trim();

                if (singersData.ContainsKey(venue))
                {
                    if (singersData[venue].ContainsKey(singer))
                    {
                        singersData[venue][singer] += ticketPrice * ticketsCount;
                    }
                    else
                    {
                        singersData[venue].Add(singer, ticketPrice * ticketsCount);
                    }
                }

                if (!singersData.ContainsKey(venue))
                {
                    singersData[venue] = new Dictionary<string, long>() { { singer, ticketPrice * ticketsCount } };
                }
            }

            foreach (var venue in singersData)
            {
                Console.WriteLine($"{venue.Key}");
                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
