using System;
using System.Collections.Generic;

namespace _11.Palindromes
{
    class Palindromes
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', ',', '\t', '\n', '\r', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new SortedSet<string>();

            foreach (var word in input)
            {
                string first = word.Substring(0, word.Length / 2);
                char[] arr = word.ToCharArray();
                Array.Reverse(arr);
                string temp = new string(arr);
                string second = temp.Substring(0, temp.Length / 2);

                if (first.Equals(second))
                {
                    result.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}
