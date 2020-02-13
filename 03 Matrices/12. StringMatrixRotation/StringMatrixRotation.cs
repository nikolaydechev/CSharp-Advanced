using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.StringMatrixRotation
{
    public class StringMatrixRotation
    {
        public static void Main()
        {
            string[] rotation = (Console.ReadLine().Split(new char[] { '(', ')', ' ' },
                StringSplitOptions.RemoveEmptyEntries));

            int degrees = (int.Parse((rotation[1]))) % 360;

            var words = new List<string>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                words.Add(input);
                input = Console.ReadLine();
            }

            int height = words.Count();
            int width = words.OrderBy(x => x.Length).Last().Length;
            string[] matrix = new string[height];

            for (int row = 0; row < height; row++)
            {
                matrix[row] = words[row].PadRight(width, ' ');
            }

            if (degrees == 0)
            {
                for (int row = 0; row < height; row++)
                {
                    Console.WriteLine(matrix[row]);
                }
            }
            if (degrees == 180)
            {
                for (int row = height - 1; row >= 0; row--)
                {
                    for (int col = width - 1; col >= 0; col--)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
            }
            if (degrees == 90)
            {
                for (int col = 0; col < width; col++)
                {
                    for (int row = height - 1; row >= 0; row--)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
            }
            if (degrees == 270)
            {
                for (int col = width - 1; col >= 0; col--)
                {
                    for (int row = 0; row < height; row++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
