using System;
using System.Collections.Generic;

namespace _10.TheHeiganDance
{
    public class HeiganDance
    {
        public static double PlayerPoints = 18500;
        public static double HeiganPoints = 3000000;
        public static bool hitByMagic = false;

        public static void Main()
        {
            List<List<char>> chamber = InitializeMatrix();

            var playerRow = 7;
            var playerCol = 7;
            chamber[playerRow][playerCol] = 'P';

            var Damage = double.Parse(Console.ReadLine());

            var hitByCloud = false;
            var InRangeOfHeigan = false;
            string castedSpell = "";

            while (true)
            {
                var inputTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var spell = inputTokens[0];
                var row = int.Parse(inputTokens[1]);
                var col = int.Parse(inputTokens[2]);

                MagicHit(row, col, chamber, ref InRangeOfHeigan);
                //PrintTemporary(chamber);
                //Console.WriteLine($"PlayerRow:{playerRow}");
                //Console.WriteLine($"PlayerCol:{playerCol}");
                //Console.WriteLine("******************");
                HeiganPoints -= Damage;

                if (hitByCloud)
                {
                    PlayerPoints -= 3500;
                    hitByCloud = false;
                }

                if (HeiganPoints <= 0 || PlayerPoints <= 0)
                {
                    Console.WriteLine(HeiganPoints <= 0 ? "Heigan: Defeated!" : $"Heigan: {HeiganPoints:F2}");
                    //if (spell == "Cloud") spell = "Plague Cloud";

                    Console.WriteLine(PlayerPoints <= 0 ? $"Player: Killed by {castedSpell}" : $"Player: {PlayerPoints}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }

                ///////////////////////// PLAYER TURN ////////////////////////////

                PlayerTurn(chamber, ref playerRow, ref playerCol, ref InRangeOfHeigan, ref hitByCloud, spell,ref castedSpell);

                //////////////////////// PLAYER TURN HAS ENDED ///////////////////



                if (HeiganPoints <= 0 || PlayerPoints <= 0)
                {
                    Console.WriteLine(HeiganPoints <= 0 ? "Heigan: Defeated!" : $"Heigan: {HeiganPoints:F2}");
                    //if (spell == "Cloud") spell = "Plague Cloud";

                    Console.WriteLine(PlayerPoints <= 0 ? $"Player: Killed by {castedSpell}" : $"Player: {PlayerPoints}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                    break;
                }



                ClearingTheChamber(chamber);
                chamber[playerRow][playerCol] = 'P';
                //PrintTemporary(chamber);
            }
        }

        private static List<List<char>> InitializeMatrix()
        {
            var chamber = new List<List<char>>(15);
            for (int i = 0; i < 15; i++)
            {
                chamber.Add(new List<char>(15));
                for (int j = 0; j < 15; j++)
                {
                    chamber[i].Add('0');
                }
            }

            return chamber;
        }

        private static void PlayerTurn(List<List<char>> chamber, ref int playerRow, ref int playerCol, ref bool InRangeOfHeigan, ref bool hitByCloud, string spell, ref string castedSpell)
        {
            if (!InRangeOfHeigan)
            {
                return;
            }

            //TRY MOVING UP
            if (playerRow - 1 < 0 || chamber[playerRow - 1][playerCol] == 'M')
            {   //TRY MOVING RIGHT
                if (playerCol > chamber[playerRow].Count - 1 || chamber[playerRow][playerCol + 1] == 'M')
                {   //TRY MOVING DOWN
                    if (playerRow + 1 > chamber.Count - 1 ||chamber[playerRow + 1][playerCol] == 'M')
                    {   //TRY MOVING LEFT
                        if (playerCol - 1 < 0 || chamber[playerRow][playerCol - 1] == 'M')
                        {
                            hitByMagic = true;
                        }
                        else
                        {//MOVING LEFT
                            playerCol = playerCol - 1;
                            //chamber[playerRow][playerCol - 1] = 'P';
                        }
                    }
                    else
                    {//MOVING DOWN
                        playerRow = playerRow + 1;
                        //chamber[playerRow + 1][playerCol] = 'P';
                    }
                }
                else
                {//MOVING RIGHT
                    playerCol = playerCol + 1;
                    //chamber[playerRow][playerCol + 1] = 'P';
                }
            }
            else
            {//MOVING UP
                playerRow = playerRow - 1;
                // chamber[playerRow - 1][playerCol] = 'P';
            }



            InRangeOfHeigan = false;

            if (hitByMagic)
            {
                if (spell == "Cloud")
                {
                    PlayerPoints -= 3500;
                    castedSpell = "Plague Cloud";
                    hitByCloud = true;
                }
                else
                {
                    PlayerPoints -= 6000;
                    castedSpell = spell;
                }
            }

            hitByMagic = false;
        }

        private static void ClearingTheChamber(List<List<char>> chamber)
        {
            for (int rowsIndex = 0; rowsIndex < chamber.Count; rowsIndex++)
            {
                for (int colsIndex = 0; colsIndex < chamber[rowsIndex].Count; colsIndex++)
                {
                    if (chamber[rowsIndex][colsIndex] == 'M' || chamber[rowsIndex][colsIndex] == 'P')
                    {
                        chamber[rowsIndex][colsIndex] = '0';
                    }
                }
            }
        }

        private static void MagicHit(int row, int col, List<List<char>> chamber, ref bool InRangeOfHeigan)
        {
            var rowIndexStart = (row - 1) < 0 ? 0 : row - 1;
            var rowIndexEnd = (row + 1) > chamber.Count - 1 ? chamber.Count - 1 : row + 1;

            var colIndexStart = (col - 1) < 0 ? 0 : col - 1;
            var colIndexEnd = (col + 1) > chamber[0].Count - 1 ? chamber[0].Count - 1 : col + 1;

            for (int rowsIndex = rowIndexStart; rowsIndex <= rowIndexEnd; rowsIndex++)
            {
                for (int colIndex = colIndexStart; colIndex <= colIndexEnd; colIndex++)
                {
                    if (chamber[rowsIndex][colIndex] == 'P')
                    {
                        InRangeOfHeigan = true;
                    }
                    else
                    {
                        chamber[rowsIndex][colIndex] = 'M';
                    }
                }
            }
        }

        private static void PrintTemporary(List<List<char>> chamber)
        {
            foreach (var rows in chamber)
            {
                Console.WriteLine(string.Join(" ", rows));
            }
            Console.WriteLine("-------------------");
        }

    }
}
