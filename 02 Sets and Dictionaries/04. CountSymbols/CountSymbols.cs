using System;
using System.Collections.Generic;

namespace _04.CountSymbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            var wordsCount = new SortedDictionary<char, int>();

            var text = Console.ReadLine();

            foreach (var letter in text)
            {
                if (!wordsCount.ContainsKey(letter))
                {
                    wordsCount.Add(letter, 0);
                }

                wordsCount[letter]++;
            }

            foreach (var kvp in wordsCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
