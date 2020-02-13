using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MaximumSum
{
    public class MaximumSum
    {
        public static void Main()
        {
            var inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var r = inputNums[0];
            var c = inputNums[1];

            int[][] matrix = new int[r][];

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var square3x3 = new List<List<int>>();
            var maxSum = int.MinValue;


            for (int rows = 0; rows < matrix.Length - 2; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length - 2; cols++)
                {
                    var sum = 0;
                    sum += matrix[rows][cols] + matrix[rows][cols + 1] + matrix[rows][cols + 2]
                           + matrix[rows + 1][cols] + matrix[rows + 1][cols + 1] + matrix[rows + 1][cols + 2]
                           + matrix[rows + 2][cols] + matrix[rows + 2][cols + 1] + matrix[rows + 2][cols + 2];

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        square3x3 = new List<List<int>>()
                        {
                            new List<int>()
                            {
                                matrix[rows][cols] , matrix[rows][cols + 1] , matrix[rows][cols + 2]
                            },
                            new List<int>()
                            {
                                matrix[rows + 1][cols] , matrix[rows + 1][cols + 1] , matrix[rows + 1][cols + 2]
                            },
                            new List<int>()
                            {
                                matrix[rows + 2][cols] , matrix[rows + 2][cols + 1] , matrix[rows + 2][cols + 2]
                            }
                        };

                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            foreach (var row in square3x3)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
