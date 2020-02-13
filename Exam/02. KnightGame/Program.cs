using System;
using System.Collections.Generic;

namespace _02.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());

            var matrix = new char[N][];

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();
                matrix[i] = new char[N];
                for (int j = 0; j < N; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i][j] == 'K')
                    {
                        DoesHitAnotherKnight(matrix[i][j], matrix);
                    }
                }
            }



            //foreach (var VARIABLE in matrix)
            //{
            //    Console.Write(string.Join(" ", VARIABLE));
            //    Console.WriteLine();
            //}
        }

        private static bool DoesHitAnotherKnight(char c, char[][] matrix)
        {
            
        }
    }
}
