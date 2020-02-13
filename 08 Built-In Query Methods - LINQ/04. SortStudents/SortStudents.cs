using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SortStudents
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class SortStudents
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var studentList = new List<Student>();

            while (input != "END")
            {
                string[] inputParams = input.Split(' ');
                var firstName = inputParams[0];
                var lastName = inputParams[1];

                var student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                };

                studentList.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in studentList.OrderBy(x => x.LastName).ThenByDescending(x => x.FirstName))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
