using System;
using System.Linq;

namespace _08.RadioactiveMutantVampireBunnies
{
    public class RadioactiveBunnies
    {
        public static bool playerLose = false;
        public static int[] position = new int[2];

        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var inputNums = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            var r = inputNums[0];
            var c = inputNums[1];

            char[][] matrix = new char[r][];

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = new char[c];
                matrix[rows] = Console.ReadLine().ToCharArray();
            }

            //var playerRow = matrix.Where(x => x.Any(y => y == 'P'));

            var commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case 'L':
                        matrix = MovingPlayer(matrix, commands[i]);
                        matrix = MovingBunnies(matrix);
                        break;
                    case 'R':
                        matrix = MovingPlayer(matrix, commands[i]);
                        matrix = MovingBunnies(matrix);
                        break;
                    case 'U':
                        matrix = MovingPlayer(matrix, commands[i]);
                        matrix = MovingBunnies(matrix);
                        break;
                    case 'D':
                        matrix = MovingPlayer(matrix, commands[i]);
                        matrix = MovingBunnies(matrix);
                        break;
                }
                if (playerLose)
                {
                    break;
                }
            }


            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.WriteLine(playerLose ? $"dead: {string.Join(" ", position)}" : $"won: {string.Join(" ", position)}");

            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            Console.WriteLine(ts);
            Console.WriteLine(watch.ElapsedTicks);
        }

        public static char[][] MovingPlayer(char[][] matrix, char command)
        {
            var demo = matrix;
            //bool hasMoved = false;

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    if (demo[rows][cols] == 'P')
                    {
                        //MOVING TO LEFT
                        if (command == 'L' && cols - 1 >= 0)
                        {
                            if (demo[rows][cols - 1] == 'B')
                            {
                                position[0] = rows;
                                position[1] = cols - 1;
                                demo[rows][cols] = '.';
                                playerLose = true;
                                return demo;
                            }
                            if (demo[rows][cols - 1] == '.')
                            {
                                demo[rows][cols - 1] = 'P';
                                demo[rows][cols] = '.';
                                return demo;
                            }
                        }
                        else if (command == 'L' && cols - 1 < 0)
                        {
                            position[0] = rows;
                            position[1] = cols;
                            demo[rows][0] = '.';
                            return demo;
                        }

                        //MOVING TO RIGHT

                        if (command == 'R' && cols + 1 <= demo[rows].Length - 1)
                        {
                            if (demo[rows][cols + 1] == 'B')
                            {
                                position[0] = rows;
                                position[1] = cols + 1;
                                demo[rows][cols] = '.';
                                playerLose = true;
                                return demo;
                            }
                            if (demo[rows][cols + 1] == '.')
                            {
                                demo[rows][cols + 1] = 'P';
                                demo[rows][cols] = '.';
                                return demo;
                            }
                        }
                        else if (command == 'R' && cols + 1 > demo[rows].Length - 1)
                        {
                            position[0] = rows;
                            position[1] = cols;
                            demo[rows][cols] = '.';
                            return demo;
                        }

                        //MOVING DOWN
                        if (command == 'D' && rows + 1 <= demo.Length - 1)
                        {
                            if (demo[rows + 1][cols] == 'B')
                            {
                                position[0] = rows + 1;
                                position[1] = cols;
                                demo[rows][cols] = '.';
                                playerLose = true;
                                return demo;
                            }
                            if (demo[rows + 1][cols] == '.')
                            {
                                demo[rows + 1][cols] = 'P';
                                demo[rows][cols] = '.';
                                return demo;
                            }
                        }
                        else if (command == 'D' && rows + 1 > demo.Length - 1)
                        {
                            position[0] = rows;
                            position[1] = cols;
                            demo[rows][cols] = '.';
                            return demo;
                        }

                        //MOVING UP
                        if (command == 'U' && rows - 1 >= 0)
                        {
                            if (demo[rows - 1][cols] == 'B')
                            {
                                position[0] = rows - 1;
                                position[1] = cols;
                                demo[rows][cols] = '.';
                                playerLose = true;
                                return demo;
                            }
                            if (demo[rows - 1][cols] == '.')
                            {
                                demo[rows - 1][cols] = 'P';
                                demo[rows][cols] = '.';
                                return demo;
                            }
                        }
                        else if (command == 'U' && rows - 1 < 0)
                        {
                            position[0] = rows;
                            position[1] = cols;
                            demo[rows][cols] = '.';
                            return demo;
                        }
                    }
                }
                if (playerLose)
                {
                    break;
                }
            }

            //foreach (var row in matrix)
            //{
            //    Console.WriteLine(string.Join("", row));
            //}
            //Console.WriteLine("------------");
            //Console.WriteLine(playerLose);

            return demo;
        }

        public static char[][] MovingBunnies(char[][] matrix)
        {
            var demo = matrix;

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    if (demo[rows][cols] == 'B')
                    {
                        //MOVING TO LEFT
                        if (cols - 1 >= 0)
                        {
                            playerLose = CheckingIfplayerLose(demo[rows][cols - 1], playerLose, rows, cols - 1);

                            if (demo[rows][cols - 1] == '.' || demo[rows][cols - 1] == 'P')
                            {
                                demo[rows][cols - 1] = 'b';
                            }
                        }
                        //MOVING TO RIGHT
                        if (cols + 1 < demo[rows].Length)
                        {
                            playerLose = CheckingIfplayerLose(demo[rows][cols + 1], playerLose, rows, cols + 1);

                            if (demo[rows][cols + 1] == '.' || demo[rows][cols + 1] == 'P')
                            {
                                demo[rows][cols + 1] = 'b';
                            }
                        }
                        //MOVING DOWN
                        if (rows + 1 < demo.Length)
                        {
                            playerLose = CheckingIfplayerLose(demo[rows + 1][cols], playerLose, rows + 1, cols);

                            if (demo[rows + 1][cols] == '.' || demo[rows + 1][cols] == 'P')
                            {
                                demo[rows + 1][cols] = 'b';
                            }
                        }
                        //MOVING UP
                        if (rows - 1 >= 0)
                        {
                            playerLose = CheckingIfplayerLose(demo[rows - 1][cols], playerLose, rows - 1, cols);

                            if (demo[rows - 1][cols] == '.' || demo[rows - 1][cols] == 'P')
                            {
                                demo[rows - 1][cols] = 'b';
                            }
                        }
                    }
                }
            }

            for (int rows = 0; rows < demo.Length; rows++)
            {
                for (int cols = 0; cols < demo[rows].Length; cols++)
                {
                    if (demo[rows][cols] == 'b')
                    {
                        demo[rows][cols] = 'B';
                    }
                }
            }

            //foreach (var row in matrix)
            //{
            //    Console.WriteLine(string.Join("", row));
            //}
            //Console.WriteLine("------------");
            //Console.WriteLine(playerLose);

            return demo;
        }

        public static bool CheckingIfplayerLose(char cellToStep, bool playerLose, int row, int col)
        {
            if (cellToStep == 'P')
            {
                position[0] = row;
                position[1] = col;
                playerLose = true;
            }

            return playerLose;
        }
    }
}
