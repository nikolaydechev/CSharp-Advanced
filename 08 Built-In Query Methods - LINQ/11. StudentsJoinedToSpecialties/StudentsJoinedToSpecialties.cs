using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.StudentsJoinedToSpecialties
{
    public class Student
    {
        public string StudentName { get; set; }

        public int FacultyNumber { get; set; }
    }

    public class StudentSpecialty
    {
        public string SpecialtyName { get; set; }

        public int FacultyNumber { get; set; }
    }

    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            var specialtiesList = new List<StudentSpecialty>();
            var studentsList = new List<Student>();

            var input = Console.ReadLine();

            while (input != "Students:")
            {
                string[] inputParams = input.Split(' ');
                var specialtyName = inputParams[0] + " " + inputParams[1];
                var facultyNumber = int.Parse(inputParams[inputParams.Length - 1]);

                var specialty = new StudentSpecialty()
                {
                    SpecialtyName = specialtyName,
                    FacultyNumber = facultyNumber
                };

                specialtiesList.Add(specialty);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputParams = input.Split(' ');
                var facultyNumber = int.Parse(inputParams[0]);
                var studentName = string.Join(" ", inputParams.Skip(1));

                var student = new Student()
                {
                    FacultyNumber = facultyNumber,
                    StudentName = studentName
                };

                studentsList.Add(student);

                input = Console.ReadLine();
            }

            var studentSpecialties =
                studentsList
                    .Join(
                        specialtiesList,
                        st => st.FacultyNumber,
                        s => s.FacultyNumber,
                        (st, s) => new
                        {
                            StudentName = st.StudentName,
                            FacultyNumber = s.FacultyNumber,
                            Specialty = s.SpecialtyName
                        });

            foreach (var item in studentSpecialties.OrderBy(x => x.StudentName))
            {
                Console.WriteLine(item.StudentName + " " + item.FacultyNumber + " " + item.Specialty);
            }
        }
    }
}
