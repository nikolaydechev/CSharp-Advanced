using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StudentsByFirstAndLastName
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }

    class StudentsByFirstAndLastName
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

                var student = new Student(firstName, lastName);
                
                studentList.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in studentList
                .Where(s => String.Compare(s.FirstName, s.LastName, StringComparison.Ordinal) < 0))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
