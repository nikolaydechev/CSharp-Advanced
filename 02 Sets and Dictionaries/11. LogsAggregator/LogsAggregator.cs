using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.LogsAggregator
{
    public class LogsAggregator
    {
        public static void Main()
        {
            var logsData = new Dictionary<string, Dictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                var ipAddress = input[0];
                var userName = input[1];
                var duration = int.Parse(input[2]);

                if (logsData.ContainsKey(userName))
                {
                    if (!logsData[userName].ContainsKey(ipAddress))
                    {
                        logsData[userName].Add(ipAddress, duration);
                    }
                    else
                    {
                        logsData[userName][ipAddress] += duration;
                    }
                }

                if (!logsData.ContainsKey(userName))
                {
                    logsData[userName] = new Dictionary<string, int>() { { ipAddress, duration } };
                }
            }

            foreach (var log in logsData.OrderBy(x => x.Key))
            {
                var totalDuration = logsData[log.Key].Values.Sum();
                Console.Write($"{log.Key}: {totalDuration} ");
                Console.WriteLine($"[{string.Join(", ", log.Value.Keys.OrderBy(x=>x))}]");
            }
        }
    }
}
