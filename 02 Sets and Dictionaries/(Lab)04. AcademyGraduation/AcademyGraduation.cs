using System;
using System.Collections.Generic;
using System.Linq;

namespace _Lab_04.AcademyGraduation
{
    public class AcademyGraduation
    {
        public static void Main()
        {
            var averageScores = new SortedDictionary<string, double>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();

                var gradesAverage = 
                        Console.ReadLine()
                            .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .ToArray()
                            .Average();

                averageScores[name] = gradesAverage;
            }

            foreach (var student in averageScores)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value}");
            }
        }
    }
}
