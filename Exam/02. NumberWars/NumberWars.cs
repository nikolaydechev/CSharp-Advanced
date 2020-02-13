using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.NumberWars
{
    class NumberWars
    {
        static void Main()
        {
            var lettersPower = new Dictionary<char, int>();
            var count = 1;
            for (char i = 'a'; i <= 'z'; i++)
            {
                lettersPower.Add(i, i);
                count++;
            }
            var firstPlayerCards = Console.ReadLine().Split().ToList();
            var secondPlayerCards = Console.ReadLine().Split().ToList();

            int player1Card = firstPlayerCards.Count - 1;
            int player2Card = secondPlayerCards.Count - 1;
            var moreThanTwoCardsWon = new List<string>();

            while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                //var cardsWon = 1;
                var currentFirstPlayerCard = firstPlayerCards[player1Card];
                var currentSecondPlayerCard = secondPlayerCards[player2Card];
                int result = string.Compare(currentFirstPlayerCard, currentSecondPlayerCard, true);
                if (result < 0)
                {
                    firstPlayerCards.Insert(0, currentFirstPlayerCard);
                    firstPlayerCards.Insert(0, currentSecondPlayerCard);

                    secondPlayerCards.Remove(secondPlayerCards[secondPlayerCards.Count - 1]);

                    player1Card--;
                    player2Card--;
                }
                else if (result > 0)
                {
                    secondPlayerCards.Insert(0, currentFirstPlayerCard);
                    secondPlayerCards.Insert(0, currentSecondPlayerCard);
                    firstPlayerCards.Remove(firstPlayerCards[firstPlayerCards.Count - 1]);

                    player1Card--;
                    player2Card--;
                }
                else
                {
                    var firstSum = 0;
                    var secondSum = 0;
                    for (int i = firstPlayerCards.Count - 1; i >= firstPlayerCards.Count - 3; i--)
                    {
                        firstSum += lettersPower[firstPlayerCards[i][firstPlayerCards[i].Length - 1]];
                    }
                    for (int i = secondPlayerCards.Count - 1; i >=  secondPlayerCards.Count - 3; i--)
                    {
                        secondSum += lettersPower[secondPlayerCards[i][secondPlayerCards[i].Length - 1]];
                    }
                    if (firstSum > secondSum)
                    {
                        firstPlayerCards.InsertRange(0, );
                    }
                }
            }


        }
    }
}
