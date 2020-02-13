using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.ShmoogleCounter
{
    public class ShmoogleCounter
    {
        public static void Main()
        {
            var resultDoubles = new List<string>();
            var resultInts = new List<string>();

            var sb = new StringBuilder();

            var input = Console.ReadLine();

            while (input != "//END_OF_CODE")
            {
                sb.AppendLine(input);
                input = Console.ReadLine();
            }

            var regexInts = new Regex(@"\bint\s*([a-z][A-Za-z]{0,24})").Matches(sb.ToString());
            var regexDoubles = new Regex(@"\bdouble\s*([a-z][A-Za-z]{0,24})").Matches(sb.ToString());

            foreach (Match match in regexDoubles)
            {
                resultDoubles.Add(match.Groups[1].Value);
            }
            foreach (Match match in regexInts)
            {
                resultInts.Add(match.Groups[1].Value);
            }

            resultDoubles = resultDoubles.OrderBy(x => x).ToList();
            resultInts = resultInts.OrderBy(x => x).ToList();
        

            Console.WriteLine(resultDoubles.Count == 0
                ? $"Doubles: None"
                : $"Doubles: {string.Join(", ", resultDoubles)}");

            Console.WriteLine(resultInts.Count == 0 
                ? $"Ints: None" 
                : $"Ints: {string.Join(", ", resultInts)}");
        }
    }
}
