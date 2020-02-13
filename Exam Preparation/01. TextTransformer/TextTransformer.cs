using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextTransformer
{
    public class TextTransformer
    {
        public static void Main()
        {
            var symbolsWeights = new Dictionary<char, int>() { { '$', 1 }, { '%', 2 }, { '&', 3 }, { '\'', 4 } };
            var sb = new StringBuilder();
            var input = Console.ReadLine();

            while (input != "burp")
            {
                sb.Append(input);

                input = Console.ReadLine();
            }

            var text = Regex.Replace(sb.ToString(), @"\s{2,}", " ");
            var regex = new Regex(@"([\$\%\&\'])[^\$\%\&\'\s]+\1").Matches(text);

            var wordsToTransform = new List<string>();

            foreach (Match match in regex)
            {
                wordsToTransform.Add(match.Value);
            }

            var result = TransformWords(wordsToTransform, symbolsWeights);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<string> TransformWords(List<string> wordsToTransform, Dictionary<char, int> symbolsWeights)
        {
            var resultWords = new List<string>();

            foreach (var word in wordsToTransform)
            {
                var transformedWord = "";
                for (int i = 1; i < word.Length - 1; i++)
                {
                    if ((i - 1) % 2 == 0)
                    {
                        transformedWord += (char)((int)word[i] + symbolsWeights[word[0]]);
                    }
                    else
                    {
                        transformedWord += (char)((int)word[i] - symbolsWeights[word[0]]);
                    }
                }

                resultWords.Add(transformedWord);
            }

            return resultWords;
        }
    }
}
