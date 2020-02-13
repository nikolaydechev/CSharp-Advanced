using System;
using System.Collections.Generic;
using System.Linq;

namespace _Lab_01.StudentsResults
{
    public class StudentsResult
    {
        public static void Main()
        {
            var results = new Dictionary<string, double[]>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var student = input[0];
                results[student] = input.Skip(1).Select(double.Parse).ToArray();
            }

            Console.WriteLine(string.Format("{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            foreach (var student in results)
            {
                Console.WriteLine(string.Format("{0, -10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|", 
                    student.Key, student.Value[0], student.Value[1], student.Value[2], student.Value.Average()));

            }
        }
    }
}
