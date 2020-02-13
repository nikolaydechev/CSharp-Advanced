using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.StudentsEnrolledIn2014_2015
{
    public class StudentsEnrolled
    {
        public static void Main()
        {
            var studentsData = new List<string[]>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputParams = input.Split().ToArray();
                studentsData.Add(inputParams);
                input = Console.ReadLine();
            }

            studentsData
                .Where(x => x[0].EndsWith("14") || x[0].EndsWith("15"))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Join(" ", x.Skip(1))));
        }
    }
}
