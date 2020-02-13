using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.StudentsByAge
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }

    public class StudentsByAge
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
                var age = int.Parse(inputParams[2]);

                var student = new Student(firstName, lastName, age);
                
                studentList.Add(student);

                input = Console.ReadLine();
            }

            foreach (var student in studentList.Where(st => st.Age >= 18 && st.Age <= 24))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Age);
            }
        }
    }
}
