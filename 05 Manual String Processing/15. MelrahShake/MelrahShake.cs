using System;

namespace _15.MelrahShake
{
    class MelrahShake
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = Console.ReadLine();
            var match = input;


            while (match != null)
            {
                int firstIndex = match.IndexOf(pattern);
                int lastIndex = match.LastIndexOf(pattern);

                if (firstIndex > -1 && lastIndex > -1 && pattern.Length > 0)
                {
                    firstIndex = match.IndexOf(pattern);
                    match = match.Remove(firstIndex, pattern.Length);
                    lastIndex = match.LastIndexOf(pattern);
                    match = match.Remove(lastIndex, pattern.Length);

                    Console.WriteLine("Shaked it.");

                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(match);
                    break;
                } 
            }
        }
    }
}
