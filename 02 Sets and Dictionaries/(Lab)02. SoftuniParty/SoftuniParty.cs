using System;
using System.Collections.Generic;

namespace _Lab_02.SoftuniParty
{
    public class SoftuniParty
    {
        public static void Main()
        {
            var reservationsNumbers = new SortedSet<string>();
            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                reservationsNumbers.Add(input);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (reservationsNumbers.Contains(input))
                {
                    reservationsNumbers.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(reservationsNumbers.Count + "\n" + string.Join("\n", reservationsNumbers));
        }
    }
}
