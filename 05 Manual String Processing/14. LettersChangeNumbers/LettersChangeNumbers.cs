using System;
using System.Collections.Generic;

namespace _14.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        public static void Main()
        {
            var lowerLetters = new Dictionary<char, int>();
            var upperLetters = new Dictionary<char, int>();

            GetLettersPosition(lowerLetters, upperLetters);

            string[] inputParams = Console.ReadLine()
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0M;

            for (int i = 0; i < inputParams.Length; i++)
            {
                decimal sum = 0M;
                var firstLetter = inputParams[i][0];
                var secondLetter = inputParams[i][inputParams[i].Length - 1];
                var number = decimal.Parse(inputParams[i].Substring(1, inputParams[i].Length - 2));

                sum += char.IsUpper(firstLetter) ? number / upperLetters[firstLetter] : number * lowerLetters[firstLetter];
                sum -= char.IsUpper(secondLetter) ? upperLetters[secondLetter] : -lowerLetters[secondLetter];

                totalSum += sum;
            }

            Console.WriteLine("{0:F2}", totalSum);
        }

        private static void GetLettersPosition(Dictionary<char, int> lowerCase, Dictionary<char, int> upperCase)
        {
            string lowerCaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string upperCaseAlphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();

            for (int i = 0; i < lowerCaseAlphabet.Length; i++)
            {
                lowerCase.Add(lowerCaseAlphabet[i], i + 1);
            }

            for (int i = 0; i < upperCaseAlphabet.Length; i++)
            {
                upperCase.Add(upperCaseAlphabet[i], i + 1);
            }
        }
    }
}
