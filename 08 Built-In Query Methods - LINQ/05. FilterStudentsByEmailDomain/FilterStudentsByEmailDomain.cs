using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterStudentsByEmailDomain
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }

    class FilterStudentsByEmailDomain
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
                var email = inputParams[2];

                var student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                studentList.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in studentList.Where(e => e.Email.EndsWith("@gmail.com")))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
