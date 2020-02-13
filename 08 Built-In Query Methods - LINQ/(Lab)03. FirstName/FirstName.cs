using System;
using System.Linq;

namespace _Lab_03.FirstName
{
    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split().ToList();
            var letters = Console.ReadLine().Split().OrderBy(x=>x);

            string name = string.Empty;
            foreach (var letter in letters)
            {
                name = names
                    .FirstOrDefault(x => x.ToLower()
                        .StartsWith(letter.ToLower()));

                if (name != null)
                {
                    Console.WriteLine(name);
                    break;
                }
            }

            if (name == null)
            {
                Console.WriteLine("No match");
            }
        }
    }
}
