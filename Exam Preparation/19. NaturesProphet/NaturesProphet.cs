using System;
using System.Collections.Generic;
using System.Linq;

namespace _19.NaturesProphet
{
    public class NaturesProphet
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var R = dimensions[0];
            var C = dimensions[1];

            int[][] matrix = new int[R][];

            for (int rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                matrix[rowsIndex] = new int[C];
                for (int colIndex = 0; colIndex < matrix[rowsIndex].Length; colIndex++)
                {
                    matrix[rowsIndex][colIndex] = 0;
                }
            }
            
            var plantingPositions = new List<string>();
            var input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                plantingPositions.Add(input);

                input = Console.ReadLine();
            }

            var orderedPositions = plantingPositions.OrderBy(x => x).ToList();

            foreach (var orderedPosition in orderedPositions)
            {
                string[] orderedPositionParams = orderedPosition.Split();
                var plantingRow = int.Parse(orderedPositionParams[0]);
                var plantingCol = int.Parse(orderedPositionParams[1]);
                
                for (int cols = 0; cols < C; cols++)
                {
                    if (plantingCol == cols)
                    {
                        continue;
                    }
                    matrix[plantingRow][cols] += 1;
                }
                
                for (int row = 0; row < R; row++)
                {
                    matrix[row][plantingCol] += 1;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
