using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.UserLogs
{
    public class UserLogs
    {
        public static void Main()
        {
            var usersData = new SortedDictionary<string, Dictionary<string, int>>();
            var input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputParams = input.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var ipAddress = inputParams[1];
                var userName = inputParams[inputParams.Length - 1];

                if (usersData.ContainsKey(userName))
                {
                    if (usersData[userName].ContainsKey(ipAddress))
                    {
                        usersData[userName][ipAddress]++;
                    }else
                    {
                        usersData[userName].Add(ipAddress, 1);
                    }
                }
                if (!usersData.ContainsKey(userName))
                {
                    usersData[userName] = new Dictionary<string, int>();
                    usersData[userName].Add(ipAddress, 1);
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in usersData)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (var ip in kvp.Value)
                {
                    if (ip.Key.Equals(kvp.Value.Last().Key))
                    {
                        Console.Write($"{ip.Key} => {ip.Value}.");
                        break;
                    }
                    Console.Write($"{ip.Key} => {ip.Value}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
