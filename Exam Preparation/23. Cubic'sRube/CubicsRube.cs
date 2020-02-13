using System;

namespace _23.Cubic_sRube
{
    public class CubicsRube
    {
        public static void Main()
        {
            int hitCells = 0;
            long sumOfAllParticles = 0;

            var N = int.Parse(Console.ReadLine());
            
            var input = Console.ReadLine();
            while (input != "Analyze")
            {
                string[] inputParams = input.Split();
                var X = int.Parse(inputParams[0]);
                var Y = int.Parse(inputParams[1]);
                var Z = int.Parse(inputParams[2]);
                var particle = int.Parse(inputParams[3]);

                if (IsInCube(X, Y, Z, N) && particle != 0)
                {
                    sumOfAllParticles += particle;
                    hitCells++;
                }

                input = Console.ReadLine();
            }
            

            Console.WriteLine(sumOfAllParticles);
            Console.WriteLine((N * N * N) - hitCells);
        }

        private static bool IsInCube(int X, int Y, int Z, int N)
        {
            if (X >= 0 && X < N && Y >= 0 && Y < N && Z >= 0 && Z < N)
            {
                return true;
            }

            return false;
        }
    }
}
