using System;
using System.Linq;

namespace _06.TargetPractice
{
    public class TargetPractice
    {
        public static void Main()
        {
            var inputNums = Console.ReadLine().Split();
            var r = int.Parse(inputNums[0]);
            var c = int.Parse(inputNums[1]);

            var snake = Console.ReadLine().ToCharArray();

            var shotParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var impactRow = shotParameters[0];
            var impactColumn = shotParameters[1];
            var radius = shotParameters[2];

            string[][] matrix = new string[r][];

            var rowStart = 0;
            var snakePart = 0;

            // FILLING UP THE MATRIX
            for (int rows = matrix.Length - 1; rows >= 0; rows--)
            {
                matrix[rows] = new string[c];
                if (rowStart % 2 == 0)
                {
                    for (int i = matrix[rows].Length - 1; i >= 0; i--)
                    {
                        if (snakePart == snake.Length)
                        {
                            snakePart = 0;
                        }
                        matrix[rows][i] = snake[snakePart].ToString();
                        snakePart++;
                    }
                }
                else
                {
                    for (int cols = 0; cols < matrix[rows].Length; cols++)
                    {
                        if (snakePart == snake.Length)
                        {
                            snakePart = 0;
                        }
                        matrix[rows][cols] = snake[snakePart].ToString();
                        snakePart++;
                    }
                }
                rowStart++;
            }

            // REMOVING ELEMENTS (GUNSHOT)
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if ((row - impactRow) * (row - impactRow) + (col - impactColumn) * (col - impactColumn) <= radius * radius)
                    {
                        matrix[row][col] = " ";
                    }
                }
            }

            // MOVING ELEMENTS DOWN
            for (int cols = 0; cols < c; cols++)
            {
                while (true)
                {
                    bool hasFallen = false;

                    for (int rows = 1; rows < matrix.Length; rows++)
                    {
                        var topLetter = matrix[rows - 1][cols];
                        var currentLetter = matrix[rows][cols];
                        if (currentLetter == " " && topLetter != " ")
                        {
                            matrix[rows][cols] = topLetter;
                            matrix[rows - 1][cols] = " ";
                            hasFallen = true;
                        }
                    }

                    if (!hasFallen)
                    {
                        break;
                    }
                }
            }

            // PRINTING THE RESULT FROM MATRIX
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
