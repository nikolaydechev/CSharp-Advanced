using System;
using System.Collections.Generic;
using System.Linq;

namespace _Lab_04.SpecialWords
{
    public class SpecialWords
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine().Split(new[] { '(', ')', '[', ']', '<', '>', '-', '!', '?', ' ' }).ToList();

            var inputText = Console.ReadLine().Split(new[] { '(', ')', '[', ']', '<', '>', '-', '!', '?', ' ' }).ToList();

            var result = new List<string>();

            foreach (string word in specialWords)
            {
                var count = inputText.Count(x => x == word);
                result.Add(word + " - " + count);
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
