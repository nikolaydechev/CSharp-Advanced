using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            long[][] matrix = new long[size][];

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            }

            long primaryDiagonal = 0;
            long secondaryDiagonal = 0;

            var col = matrix.Length - 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                primaryDiagonal += matrix[row][row];
                secondaryDiagonal += matrix[row][col];
                col--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));

        }
    }
}
