using System;
using System.Text.RegularExpressions;

namespace _Lab_02.ParseURLs
{
    public class ParseURLs
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            int count = new Regex(Regex.Escape("://")).Matches(input).Count;
            int secondCount = input.Split('/').Length - 1;

            if (count != 1 || secondCount < 3)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var inputParams = input.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            var protocol = inputParams[0];
            var server = inputParams[1].Substring(0, inputParams[1].IndexOf('/'));
            var resources = inputParams[1].Substring(server.Length + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resources}");
        }
    }
}
