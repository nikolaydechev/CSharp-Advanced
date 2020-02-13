using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PhoneBook
{
    public class PhoneBook
    {
        public static void Main()
        {
            var phoneBook = new Dictionary<string, string>();
            var input = Console.ReadLine();

            while (input != "search")
            {
                var inputLine = input
                    .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var userName = inputLine[0];
                var phoneNumber = inputLine[1];

                if (!phoneBook.ContainsKey(userName))
                {
                    phoneBook.Add(userName, string.Empty);
                }

                phoneBook[userName] = phoneNumber;
                
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                Console.WriteLine(phoneBook.ContainsKey(input)
                    ? $"{input} -> {phoneBook[input]}"
                    : $"Contact {input} does not exist.");

                input = Console.ReadLine();
            }
        }
    }
}
