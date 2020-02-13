using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var r = inputNumbers[0];
            var c = inputNumbers[1];

            string[][] matrix = new string[r][];

            for (int row = 0; row < r; row++)
            {
                matrix[row] = new string[c];
            }

            for (int rows = 0; rows < r; rows++)
            {
                for (int cols = 0; cols < c; cols++)
                {
                    matrix[rows][cols] = alphabet[rows].ToString() + alphabet[rows + cols] + alphabet[rows];
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
