using System;

namespace _Lab_04.PascalTriangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = new long[row + 1];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;
            }
            
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var sum = matrix[row][col] + matrix[row][col + 1];
                    matrix[row + 1][col + 1] = sum;
                }
            }
            
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
