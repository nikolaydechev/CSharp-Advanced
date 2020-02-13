using System;
using System.Linq;

namespace _Lab_01.SumMatrixElements
{
    public class SumMatrixElements
    {
        public static void Main()
        {
            var numberOfRowsAndCols =
                    Console.ReadLine()
                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int[][] matrix = new int[numberOfRowsAndCols[0]][];
            var totalSum = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                                            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

                totalSum += matrix[rowIndex].Sum();
            }

            Console.WriteLine(numberOfRowsAndCols[0]);
            Console.WriteLine(numberOfRowsAndCols[1]);
            Console.WriteLine(totalSum);

        }
    }
}
