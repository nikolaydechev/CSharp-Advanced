using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _Lab_05.ExtractTags
{
    public class ExtractTags
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"<[^>][^<]*>");
            var htmlTags = new List<MatchCollection>();

            while (input != "END")
            {
                var matches = regex.Matches(input);
                htmlTags.Add(matches);

                input = Console.ReadLine();
            }
            
            foreach (MatchCollection matches in htmlTags)
            {
                foreach (Match tag in matches)
                {
                    Console.WriteLine(tag);
                }
            }
        }
    }
}
