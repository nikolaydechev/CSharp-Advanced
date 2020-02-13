using System;
using System.Linq;

namespace _Lab_02.MaximumSumOf2x2Submatrix
{
    public class MaximumSumOf2x2Submatrix
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            int[][] matrix = new int[int.Parse(input[0])][];

            for (int rowIndex = 0; rowIndex < int.Parse(input[0]); rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            }

            var maxSum = 0;
            var maxSquareRow = 0;
            var maxSquareCol = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    var currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                                     matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxSquareRow = rowIndex;
                        maxSquareCol = colIndex;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxSquareRow][maxSquareCol]} {matrix[maxSquareRow][maxSquareCol + 1]}\n" +
                              $"{matrix[maxSquareRow + 1][maxSquareCol]} {matrix[maxSquareRow + 1][maxSquareCol + 1]}");

            Console.WriteLine(maxSum);
        }
    }
}
