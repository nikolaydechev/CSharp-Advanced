using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    public class Crossfire
    {
        private const int Empty = 0;

        public static void Main()
        {
            var dimensions = Console.ReadLine().Split();
            var r = int.Parse(dimensions[0]);
            var c = int.Parse(dimensions[1]);

            long[][] matrix = FillMatrix(r, c);
            var jaggedList = matrix.Select(x => x.ToList()).ToList();

            var command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                string[] commands = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var impactRow = int.Parse(commands[0]);
                var impactColumn = int.Parse(commands[1]);
                var radius = int.Parse(commands[2]);

                MakingMatchesEmpty(jaggedList, impactRow, impactColumn, radius);
                RearrangingMatrix(jaggedList);
                
                command = Console.ReadLine();
            }


            foreach (var rows in jaggedList)
            {
                Console.WriteLine(string.Join(" ", rows));
            }
        }

        private static long[][] FillMatrix(int r, int c)
        {
            long[][] matrix = new long[r][];
            var count = 1;
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = new long[c];
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    matrix[rows][cols] = count;
                    count++;
                }
            }

            return matrix;
        }

        public static void RearrangingMatrix(List<List<long>> jaggedList)
        {
            for (int rowIndex = jaggedList.Count - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = jaggedList[rowIndex].Count - 1; colIndex >= 0; colIndex--)
                {
                    if (jaggedList[rowIndex][colIndex] == Empty)
                    {
                        jaggedList[rowIndex].RemoveAt(colIndex);
                    }
                }

                if (jaggedList[rowIndex].Count == 0)
                {
                    jaggedList.RemoveAt(rowIndex);
                }
            }
        }

        public static void MakingMatchesEmpty(List<List<long>> jaggedList, int impactRow, int impactColumn, int radius)
        {
            // FROM LEFT TO RIGHT
            for (int cols = impactColumn - radius; cols <= impactColumn + radius; cols++)
            {
                if (IsInMatrix(impactRow, cols, jaggedList))
                {
                    jaggedList[impactRow][cols] = Empty;
                }
            }

            // FROM UP TO DOWN
            for (int rows = impactRow - radius; rows <= impactRow + radius; rows++)
            {
                if (IsInMatrix(rows, impactColumn, jaggedList))
                {
                    jaggedList[rows][impactColumn] = Empty;
                }
            }
        }

        private static bool IsInMatrix(int currentRow, int currentCol, List<List<long>> jaggedList)
        {
            if (currentRow >= 0 && currentRow < jaggedList.Count && currentCol >= 0 && currentCol < jaggedList[currentRow].Count)
            {
                return true;
            }

            return false;
        }

    }
}
