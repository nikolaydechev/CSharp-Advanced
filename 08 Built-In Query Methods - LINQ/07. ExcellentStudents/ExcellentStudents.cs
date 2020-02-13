using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ExcellentStudents
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<int> Marks { get; set; }
    }

    class ExcellentStudents
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var studentList = new List<Student>();

            while (input != "END")
            {
                string[] inputParams = input.Split(' ');
                var firstName = inputParams[0];
                var lastName = inputParams[1];
                List<int> marks = inputParams.Skip(2).Select(int.Parse).ToList();

                var student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Marks = marks
                };

                studentList.Add(student);

                input = Console.ReadLine();
            }

            //07. EXCELLENT STUDENTS PROBLEM
            //foreach (var student in studentList.Where(st => st.Marks.Contains(6)))
            //{
            //    Console.WriteLine(student.FirstName + " " + student.LastName);
            //}

            //08. WEAK STUDENTS PROBLEM
            foreach (var student in studentList.Where(st => st.Marks.Count(m => m <= 3) >= 2))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

        }
    }
}
