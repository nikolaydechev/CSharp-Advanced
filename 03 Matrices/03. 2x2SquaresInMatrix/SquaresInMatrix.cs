using System;
using System.Linq;

namespace _03._2x2SquaresInMatrix
{
    public class SquaresInMatrix
    {
        public static void Main()
        {
            var inputNums = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            var r = inputNums[0];
            var c = inputNums[1];

            string[][] matrix = new string[r][];

            for (int row = 0; row < r; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var maxEqualCells = int.MinValue;
            var equalCellsCount = 0;

            for (int rows = 0; rows < matrix.Length - 1; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length - 1; cols++)
                {
                    if (matrix[rows][cols] == matrix[rows][cols + 1] && matrix[rows + 1][cols] == matrix[rows + 1][cols + 1])
                    {
                        if (matrix[rows][cols] == matrix[rows + 1][cols + 1])
                        {
                            equalCellsCount++;
                        }
                    }
                    if (maxEqualCells < equalCellsCount)
                    {
                        maxEqualCells = equalCellsCount;
                    }
                }
            }

            Console.WriteLine(maxEqualCells);
        }
    }
}
