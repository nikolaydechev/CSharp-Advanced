using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.JediMeditation
{
    public class JediMeditation
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            var meditators = new List<string>();

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine().Split().ToList();
                meditators.AddRange(line);
            }

            var sortedMeditators = new List<string>();
            var bulgarians = meditators.Where(x => x.StartsWith("t") || x.StartsWith("s"));
            var jediMasters = meditators.Where(x => x.StartsWith("m"));
            var jediKnights = meditators.Where(x => x.StartsWith("k"));
            var jediPadawans = meditators.Where(x => x.StartsWith("p"));

            if (!meditators.Any(x => x.StartsWith("y")))
            {
                sortedMeditators.AddRange(bulgarians);
                sortedMeditators.AddRange(jediMasters);
                sortedMeditators.AddRange(jediKnights);
                sortedMeditators.AddRange(jediPadawans);
            }
            else
            {
                sortedMeditators.AddRange(jediMasters);
                sortedMeditators.AddRange(jediKnights);
                sortedMeditators.AddRange(bulgarians);
                sortedMeditators.AddRange(jediPadawans);
            }

            Console.WriteLine(string.Join(" ", sortedMeditators));
        }
    }
}
