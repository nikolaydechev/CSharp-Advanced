using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.GroupByGroup
{
    public class Person
    {
        public List<string> Name { get; set; }

        public int Group { get; set; }
    }

    public class GroupByGroup
    {
        public static void Main()
        {
            var personList = new List<Person>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputParams = input.Split();

                var name = inputParams[0] + " " + inputParams[1];
                var group = int.Parse(inputParams[inputParams.Length - 1]);

                if (personList.All(x => x.Group != group))
                {
                    var person = new Person()
                    {
                        Name = new List<string> { name },
                        Group = group
                    };

                    personList.Add(person);
                }
                else
                {
                    var currentPerson = personList.First(x => x.Group == group);
                    currentPerson.Name.Add(name);
                }

                input = Console.ReadLine();
            }

            var result =
                personList
                    .GroupBy(st => st.Group)
                    .OrderBy(x => x.Key)
                    .ToDictionary(gr => gr.Key);
            
            foreach (var item in result)
            {
                Console.Write(item.Key + " - ");

                foreach (var person in item.Value)
                {
                    Console.WriteLine(string.Join(", ", person.Name));
                }
            }
        }
    }
}
