namespace _09.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SecondSolution
    {
        // SECOND SOLUTION WITH DATETIME AND DATETIME.TRYPARSE


        public class Events
        {
            public static DateTime eventTime;

            public class Event
            {
                public string City { get; set; }

                public SortedDictionary<string, List<DateTime>> PersonAndTime { get; set; }
            }

            public static void Main1()
            {
                var eventList = new List<Event>();
                var N = int.Parse(Console.ReadLine());

                for (int i = 0; i < N; i++)
                {
                    var input = Console.ReadLine();
                    var regex = new Regex(@"^#([A-Za-z]+):\s*@([A-Za-z]+)\s*(\d+:\d+)$").Match(input);
                    var city = regex.Groups[2].Value;
                    var person = regex.Groups[1].Value;
                    var time = regex.Groups[3].Value;

                    if (regex.Success && IsValidDate(time))
                    {
                        if (eventList.Any(x => x.City == city))
                        {
                            var currentEvent = eventList.First(x => x.City == city);
                            if (!eventList.Any(x => x.PersonAndTime.ContainsKey(person)))
                            {
                                currentEvent.PersonAndTime[person] = new List<DateTime>();
                            }
                            currentEvent.PersonAndTime[person].Add(eventTime);
                        }
                        else
                        {
                            var eventToAdd = new Event();
                            eventToAdd.City = city;
                            eventToAdd.PersonAndTime = new SortedDictionary<string, List<DateTime>>();
                            eventToAdd.PersonAndTime[person] = new List<DateTime>();
                            eventToAdd.PersonAndTime[person].Add(eventTime);
                            eventList.Add(eventToAdd);
                        }

                    }
                }

                var locationsToDisplay = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
                        var timesCollection = kvp.Value.OrderBy(x => x).Select(x => x.ToString("HH:mm"));
                        Console.WriteLine($"{count}. {kvp.Key} -> {string.Join(", ", timesCollection)}");
                        count++;
                    }
                }
            }

            private static bool IsValidDate(string d)
            {
                return DateTime.TryParse(d, out eventTime);
            }
        }


    }
}
