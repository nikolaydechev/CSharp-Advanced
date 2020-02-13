using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StudentsByGroup
{
    public class StudentsByGroup
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
                var groupNumber = int.Parse(inputParams[2]);

                var student = new Student(firstName, lastName, groupNumber);
                studentList.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in studentList.Where(n => n.GroupNumber == 2).OrderBy(x => x.FirstName))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupNumber { get; set; }

        public Student(string firstName, string lastName, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GroupNumber = groupNumber;
        }
    }
}
