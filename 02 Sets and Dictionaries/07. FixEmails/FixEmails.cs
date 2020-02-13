using System;
using System.Collections.Generic;

namespace _07.FixEmails
{
    public class FixEmails
    {
        public static void Main()
        {
            var users = new Dictionary<string, string>();

            var input = Console.ReadLine();
            var userName = "";
            var count = 1;

            while (input != "stop")
            {
                if (count % 2 != 0)
                {
                    users.Add(input, string.Empty);
                    userName = input;
                }
                else
                {
                    var extension = input.Substring(input.Length - 3);
                    if (extension.Equals(".us") || extension.Equals(".uk"))
                    {
                        users.Remove(userName);
                    }
                    else
                    {
                        users[userName] = input;
                    }
                }

                count++;
                input = Console.ReadLine();
            }

            foreach (var kvp in users)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
