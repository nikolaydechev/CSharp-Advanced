using System;
using System.Collections.Generic;

namespace _13.MagicExchangeableWords
{
    class MagicExchangeableWords
    {
        public static void Main()
        {
            string[] inputParams = Console.ReadLine().Split(' ');
            var firstString = inputParams[0];
            var secondString = inputParams[1];
            var restOfLongerString = "";

            if (firstString.Length < secondString.Length)
            {
                restOfLongerString = secondString.Substring(firstString.Length);
                secondString = secondString.Substring(0, firstString.Length);
            }
            else if (firstString.Length > secondString.Length)
            {
                restOfLongerString = firstString.Substring(secondString.Length);
                firstString = firstString.Substring(0, secondString.Length);
            }
            
            bool magicExchangeable = ExchangeableOrNot(firstString, secondString, restOfLongerString);

            Console.WriteLine(magicExchangeable ? "true" : "false");
        }

        private static bool ExchangeableOrNot(string firstString, string secondString, string restOfLongerString)
        {
            bool exchangeable = true;
            var charactersData = new Dictionary<char, char>();

            for (int i = 0; i < firstString.Length; i++)
            {
                if (!charactersData.ContainsKey(firstString[i]))
                {
                    if (!charactersData.ContainsValue(secondString[i]))
                    {
                        charactersData.Add(firstString[i], secondString[i]);
                    }
                    else
                    {
                        exchangeable = false;
                        break;
                    }
                }
                else
                {
                    if (charactersData[firstString[i]] != secondString[i])
                    {
                        exchangeable = false;
                        break;
                    }
                }
            }

            foreach (var character in restOfLongerString)
            {
                if (!charactersData.ContainsKey(character) && !charactersData.ContainsValue(character))
                {
                    exchangeable = false;
                }
            }

            return exchangeable;
        }
    }
}
