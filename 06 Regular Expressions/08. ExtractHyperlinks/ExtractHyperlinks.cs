using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _08.ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            while (input != "END")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }
            
            var regex = new Regex(@"<a.*?\shref\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>").Matches(sb.ToString());

            foreach (Match match in regex)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (match.Groups[i].Length > 0)
                    {
                        Console.WriteLine(match.Groups[i]);
                    }
                }
            }
        }
    }
}
