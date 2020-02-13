using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09.Events
{
    public class Events
    {
        public class Event
        {
            public string City { get; set; }

            public SortedDictionary<string, List<string>> PersonAndTime { get; set; }
        }

        public static void Main()
        {
            var eventList = new List<Event>();
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine();
                var regex = new Regex(@"^#([A-Za-z]+):\s*@([A-Za-z]+)\s*(([01]\d|2[0-3]):[0-5]\d)$").Match(input);
                var city = regex.Groups[2].Value;
                var person = regex.Groups[1].Value;
                var time = regex.Groups[3].Value;

                if (regex.Success)
                {
                    if (eventList.Any(x => x.City == city))
                    {
                        var currentEvent = eventList.First(x => x.City == city);
                        if (!eventList.Any(x => x.PersonAndTime.ContainsKey(person)))
                        {
                            currentEvent.PersonAndTime[person] = new List<string>();
                        }
                        currentEvent.PersonAndTime[person].Add(time);
                    }
                    else
                    {
                        var eventToAdd = new Event();
                        eventToAdd.City = city;
                        eventToAdd.PersonAndTime = new SortedDictionary<string, List<string>>();
                        eventToAdd.PersonAndTime[person] = new List<string>();
                        eventToAdd.PersonAndTime[person].Add(time);
                        eventList.Add(eventToAdd);
                    }

                }
            }

            var locationsToDisplay = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var location in locationsToDisplay.OrderBy(x => x))
            {
                if (eventList.All(x => x.City != location))
                {
                    continue;
                }
                var count = 1;
                var currentEvent = eventList.First(x => x.City == location);
                Console.WriteLine($"{location}:");

                foreach (var kvp in currentEvent.PersonAndTime)
                {
                    Console.WriteLine($"{count}. {kvp.Key} -> {string.Join(", ", kvp.Value.OrderBy(x => x))}");
                    count++;
                }
            }
        }
    }
}
