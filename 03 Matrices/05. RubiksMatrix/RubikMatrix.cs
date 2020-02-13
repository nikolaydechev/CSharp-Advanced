using System;
using System.Linq;

namespace _05.RubiksMatrix
{
    public class RubikMatrix
    {
        public static void Main()
        {
            var inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var r = inputNums[0];
            var c = inputNums[1];

            int[][] matrix = new int[r][];

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = new int[c];
            }

            var count = 1;

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    matrix[rows][cols] = count;
                    count++;
                }
            }

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var rowOrColIndex = int.Parse(command[0]);
                var direction = command[1];
                var moves = int.Parse(command[2]);

                switch (direction)
                {
                    case "left":
                        matrix[rowOrColIndex] = ShiftLeft(matrix[rowOrColIndex], moves, c);
                        break;
                    case "right":
                        matrix[rowOrColIndex] = ShiftRight(matrix[rowOrColIndex], moves, c);
                        break;
                    case "up":
                        matrix = ShiftUp(matrix, rowOrColIndex, r, moves);
                        break;
                    case "down":
                        matrix = ShiftDown(matrix, rowOrColIndex, r, moves);
                        break;
                }
            }

            var correctNumber = 1;
            
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    if (matrix[rows][cols] != correctNumber)
                    {
                        // SEARCHING FOR THE NUMBER TO SWAP
                        for (int i = 0; i < r; i++)
                        {
                            for (int j = 0; j < c; j++)
                            {
                                if (matrix[i][j] == correctNumber)
                                {
                                    var temp = matrix[rows][cols];
                                    matrix[rows][cols] = correctNumber;
                                    matrix[i][j] = temp;
                                    Console.WriteLine($"Swap ({rows}, {cols}) with ({i}, {j})");
                                }
                            }
                        }
                    }
                    else
                    {
                        // NO SWAP REQUIRED
                        Console.WriteLine($"No swap required");
                    }
                    correctNumber++;
                }
            }
        }

        private static int[][] ShiftDown(int[][] matrix, int rowOrColIndex, int r, int moves)
        {
            moves = moves % r;
            int[][] demo = new int[matrix.Length][];
            demo = matrix;
            for (int j = 0; j < moves; j++)
            {
                var lowestElement = demo[r - 1][rowOrColIndex];
                for (int i = r - 1; i > 0; i--)
                {
                    demo[i][rowOrColIndex] = demo[i - 1][rowOrColIndex];
                }
                demo[0][rowOrColIndex] = lowestElement;
            }

            return demo;
        }

        private static int[][] ShiftUp(int[][] matrix, int rowOrColIndex, int r, int moves)
        {
            moves = moves % r;
            int[][] demo = new int[matrix.Length][];
            demo = matrix;
            for (int j = 0; j < moves; j++)
            {
                var topElement = demo[0][rowOrColIndex];
                for (int i = 0; i < r - 1; i++)
                {
                    demo[i][rowOrColIndex] = demo[i + 1][rowOrColIndex];
                }
                demo[r - 1][rowOrColIndex] = topElement;
            }

            return demo;
        }

        private static int[] ShiftRight(int[] rowInts, int moves, int c)
        {
            moves = moves % c;
            int[] demo = new int[rowInts.Length];
            demo = rowInts;
            for (int i = 0; i < moves; i++)
            {
                var lowestElement = demo[demo.Length - 1];
                for (int j = demo.Length - 1; j > 0; j--)
                {
                    demo[j] = demo[j - 1];
                }
                demo[0] = lowestElement;
            }

            return demo;

        }

        private static int[] ShiftLeft(int[] rowInts, int moves, int c)
        {
            moves = moves % c;
            int[] demo = new int[rowInts.Length];
            demo = rowInts;
            for (int j = 0; j < moves; j++)
            {
                var topElement = demo[0];
                for (int i = 0; i < rowInts.Length - 1; i++)
                {
                    demo[i] = demo[i + 1];
                }

                demo[demo.Length - 1] = topElement;
            }

            return demo;
        }
    }
}
