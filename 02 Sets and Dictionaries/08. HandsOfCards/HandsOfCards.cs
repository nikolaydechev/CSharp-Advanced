using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.HandsOfCards
{
    public class HandsOfCards
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var playersData = new Dictionary<string, List<string>>();
            var playerAndCardsValue = new Dictionary<string, int>();

            while (input != "JOKER")
            {
                string[] inputParams = input.Split(new[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var playerName = inputParams[0];
                var playerCards = inputParams.Skip(1).Select(x => x.Trim()).ToList();

                if (!playersData.ContainsKey(playerName))
                {
                    playersData[playerName] = new List<string>();
                }

                foreach (var card in playerCards)
                {
                    if (!playersData[playerName].Contains(card))
                    {
                        playersData[playerName].Add(card);
                    }
                }

                input = Console.ReadLine();
            }


            foreach (var kvp in playersData)
            {
                var cardsValue = CalculateCardsValue(kvp.Value);

                playerAndCardsValue.Add(kvp.Key, cardsValue);
            }

            foreach (var kvp in playerAndCardsValue)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static int CalculateCardsValue(List<string> deckOfCards)
        {
            var cards = new Dictionary<string, int>()
            {
                {"S", 4 }, {"2", 2 },
                {"D", 2 }, {"4", 4 },
                {"C", 1 }, {"5", 5 },
                {"J", 11 }, {"6", 6 },
                {"Q", 12 }, {"7", 7 },
                {"K", 13 }, {"8", 8 },
                {"A", 14 }, {"9", 9 },
                {"H", 3 }, {"10", 10 },
                {"3", 3 }
            };

            var cardsValue = 0;

            foreach (var card in deckOfCards)
            {
                var firstElement = card.Substring(0, card.Length - 1);
                var secondElement = card.Substring(card.Length - 1);
                cardsValue += cards[secondElement] * cards[firstElement];
            }

            return cardsValue;
        }
    }
}
