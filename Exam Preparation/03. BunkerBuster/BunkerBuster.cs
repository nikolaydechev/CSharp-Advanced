using System;
using System.Linq;

namespace _03.BunkerBuster
{
    public class BunkerBuster
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split();
            var r = int.Parse(dimensions[0]);
            var c = int.Parse(dimensions[1]);

            var matrix = new int[r][];

            for (int i = 0; i < r; i++)
            {
                matrix[i] = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();
            }

            var bombing = Console.ReadLine();

            while (bombing != "cease fire!")
            {
                string[] bombingParams = bombing.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var bombingRow = int.Parse(bombingParams[0]);
                var bombingCol = int.Parse(bombingParams[1]);
                var powerSymbol = (decimal)bombingParams[2][0];

                matrix = BombardingTarget(matrix, bombingRow, bombingCol, powerSymbol);
                
                bombing = Console.ReadLine();
            }

            var totalCellsDestroyed = matrix.Select(row => row.Count(x => x <= 0)).Sum();
            Console.WriteLine($"Destroyed bunkers: {totalCellsDestroyed}");
            Console.WriteLine($"Damage done: {(decimal)totalCellsDestroyed * 100 / (r * c):F1} %");
        }

        private static int[][] BombardingTarget(int[][] matrix, int bombingRow, int bombingCol, decimal powerSymbol)
        {
            var startingRow = bombingRow - 1 < 0 ? 0 : bombingRow - 1;
            var endingRow = bombingRow + 1 > matrix.Length - 1 ? matrix.Length - 1 : bombingRow + 1;

            var startingCol = bombingCol - 1 < 0 ? 0 : bombingCol - 1;
            var endingCol = bombingCol + 1 > matrix[bombingRow].Length - 1
                ? matrix[bombingRow].Length - 1
                : bombingCol + 1;

            for (int rows = startingRow; rows <= endingRow; rows++)
            {
                for (int cols = startingCol; cols <= endingCol; cols++)
                {
                    if (rows == bombingRow && cols == bombingCol)
                    {
                        matrix[rows][cols] -= (int)powerSymbol;
                        continue;
                    }
                    matrix[rows][cols] -= (int)Math.Ceiling(powerSymbol / 2);
                }
            }

            return matrix;
        }
    }
}
