using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Monopoly
{
    public class Monopoly
    {
        public static void Main()
        {
            int playerMoney = 50;
            int hotelsIncome = 0;
            int numberHotels = 0;

            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var R = dimensions[0];
            var C = dimensions[1];

            var messages = new List<string>();
            var turns = 0;

            for (int i = 0; i < R; i++)
            {
                var row = Console.ReadLine();
                if (i % 2 != 0)
                {
                    for (int k = row.Length - 1; k >= 0; k--)
                    {
                        Iteration(ref playerMoney, ref hotelsIncome, ref numberHotels, messages, ref turns, i, row, k);
                        turns += 1;
                        playerMoney += hotelsIncome;
                    }
                }
                else
                {
                    for (int j = 0; j < row.Length; j++)
                    {
                        Iteration(ref playerMoney, ref hotelsIncome, ref numberHotels, messages, ref turns, i, row, j);
                        turns += 1;
                        playerMoney += hotelsIncome;
                    }
                }

            }

            Console.WriteLine(string.Join("\n", messages));
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {playerMoney}");
        }

        private static void Iteration(ref int playerMoney, ref int hotelsIncome, ref int numberHotels,
            List<string> messages, ref int turns, int i, string row, int j)
        {
            switch (row[j])
            {
                case 'H':
                    hotelsIncome += 10;
                    numberHotels += 1;
                    messages.Add($"Bought a hotel for {playerMoney}. Total hotels: {numberHotels}.");
                    playerMoney = 0;
                    break;
                case 'J':
                    messages.Add($"Gone to jail at turn {turns}.");
                    turns += 2;
                    playerMoney += hotelsIncome * 2;
                    break;
                case 'F':
                    break;
                case 'S':
                    var Row = i;
                    var Col = j;
                    var expense = (Row + 1) * (Col + 1);
                    if (playerMoney < 0) playerMoney = 0;

                    if (playerMoney == 0)
                    {
                        expense = 0;
                    }
                    else if (playerMoney > 0 && playerMoney < expense)
                    {
                        expense = playerMoney;
                    }

                    playerMoney -= expense;
                    messages.Add($"Spent {expense} money at the shop.");
                    break;
            }
        }
    }
}
