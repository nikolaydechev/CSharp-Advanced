using System;
using System.Linq;

namespace _15.JediGalaxy
{
    public class JediGalaxy
    {
        public static void Main()
        {
            long ivoSum = 0;

            var dimensions = Console.ReadLine().Split();
            var R = int.Parse(dimensions[0]);
            var C = int.Parse(dimensions[1]);

            var matrix = new int[R][];

            var counter = 0;
            for (int rows = 0; rows < R; rows++)
            {
                matrix[rows] = new int[C];
                for (int cols = 0; cols < C; cols++)
                {
                    matrix[rows][cols] = counter;
                    counter++;
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Let the Force be with you")
                {
                    break;
                }
                var ivoCoordinates = input.Split().Select(int.Parse).ToArray();
                var ivoStartingRow = ivoCoordinates[0];
                var ivoStartingCol = ivoCoordinates[1];

                input = Console.ReadLine();
                var evilCoordinates = input.Split().Select(int.Parse).ToArray();
                var evilStartingRow = evilCoordinates[0];
                var evilStartingCol = evilCoordinates[1];

                // EVIL DIAGONAL MOVEMENT
                for (int rowIndex = evilStartingRow; rowIndex >= 0; rowIndex--)
                {

                    if (IsInMatrix(matrix, rowIndex, evilStartingCol, C))
                    {
                        matrix[rowIndex][evilStartingCol] = 0;
                    }

                    if (rowIndex == 0 || evilStartingCol == 0)
                    {
                        break;
                    }

                    evilStartingCol--;
                }

                // IVO DIAGONAL MOVEMENT
                for (int rowIndex = ivoStartingRow; rowIndex >= 0; rowIndex--)
                {
                    if (IsInMatrix(matrix, rowIndex, ivoStartingCol, C))
                    {
                        ivoSum += matrix[rowIndex][ivoStartingCol];
                        //matrix[rowIndex][ivoStartingCol] = 0;
                    }
                    if (rowIndex == 0 || ivoStartingCol == C - 1)
                    {
                        break;
                    }

                    ivoStartingCol++;
                }
            }

            Console.WriteLine(ivoSum);
        }

        private static bool IsInMatrix(int[][] matrix, int rowIndex, int colIndex, int C)
        {
            if (rowIndex < matrix.Length && rowIndex >= 0 && colIndex >= 0 && colIndex < C)
            {
                return true;
            }

            return false;
        }
    }
}
