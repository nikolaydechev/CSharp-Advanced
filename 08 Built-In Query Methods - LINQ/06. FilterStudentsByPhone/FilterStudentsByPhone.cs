using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FilterStudentsByPhone
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }

    class FilterStudentsByPhone
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
                var phoneNumber = inputParams[2];

                var student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber
                };

                studentList.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in studentList
                .Where(st => st.PhoneNumber.StartsWith("02") || st.PhoneNumber.StartsWith("+3592")))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
