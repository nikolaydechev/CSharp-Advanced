using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    public class Hospital
    {
        public class Doctor
        {
            public string DoctorName { get; set; }
            public List<string> Patients { get; set; }
        }
        public class Department
        {
            public string DepartmentName { get; set; }
            public Dictionary<string, int> Patients { get; set; }
            public int Spots { get; set; }
        }


        public static void Main()
        {
            var listDoctors = new List<Doctor>();
            var listDepartments = new List<Department>();
            var input = Console.ReadLine();

            while (input != "Output")
            {
                var inputParams = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToList();
                var department = inputParams[0];
                var doctor = inputParams[1] + " " + inputParams[2];
                var patient = inputParams[3];

                if (listDoctors.All(x => x.DoctorName != doctor))
                {
                    var newDoc = new Doctor
                    {
                        DoctorName = doctor,
                        Patients = new List<string> { patient }
                    };
                    listDoctors.Add(newDoc);
                }
                else
                {
                    var currentDoctor = listDoctors.First(x => x.DoctorName == doctor);
                    currentDoctor.Patients.Add(patient);
                }

                if (listDepartments.All(x => x.DepartmentName != department))
                {
                    var depart = new Department();
                    depart.DepartmentName = department;
                    depart.Patients = new Dictionary<string, int>();
                    depart.Spots++;
                    depart.Patients[patient] = depart.Spots;
                    listDepartments.Add(depart);
                }
                else
                {
                    var currentDepartment = listDepartments.First(x => x.DepartmentName == department);
                    if (currentDepartment.Spots < 60)
                    {
                        currentDepartment.Spots++;
                        currentDepartment.Patients.Add(patient, currentDepartment.Spots);
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                var inputParams1 = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToList();

                if (inputParams1.Count < 2)
                {
                    var departToPrint = listDepartments.First(x => x.DepartmentName == input);
                    foreach (var depart in departToPrint.Patients)
                    {
                        Console.WriteLine(depart.Key);
                    }
                }
                else if (inputParams1.Count > 1)
                {
                    int roomNumber;
                    bool isDepartmentRoomData = int.TryParse(inputParams1[1], out roomNumber);
                    if (!isDepartmentRoomData)
                    {
                        var doctorToPrint = listDoctors.First(x => x.DoctorName == input.Trim());
                        Console.WriteLine(string.Join("\n", doctorToPrint.Patients.OrderBy(x=>x)));
                    }
                    else
                    {
                        var departRoomDataToPrint = listDepartments.First(x => x.DepartmentName == inputParams1[0]);
                        var spotsToPrint = (roomNumber * 3) - 3;
                        var roomNumberPeople =
                            departRoomDataToPrint.Patients.Where(
                                x => x.Value >= spotsToPrint && x.Value <= spotsToPrint + 3).OrderBy(x => x.Key);

                        foreach (var keyValuePair in roomNumberPeople)
                        {
                            Console.WriteLine(keyValuePair.Key);
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
