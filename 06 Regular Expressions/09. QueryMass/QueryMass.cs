using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _09.QueryMass
{
    public class QueryMass
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var input = Console.ReadLine();
            var tokens = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                tokens = new Dictionary<string, List<string>>();
                
                var regex = new Regex(@"([^&=?\s]*)(?=\=)=(?<=\=)([^&=\s]*)").Matches(input); //([^&=?\s]*)=([^&=\s]*)

                foreach (Match match in regex)
                {
                    var key = match.Groups[1].Value;
                    var value = match.Groups[2].Value;
                    key = Regex.Replace(key, @"((%20|\+)+)", " ").Trim();
                    value = Regex.Replace(value, @"((%20|\+)+)", " ").Trim();

                    if (!tokens.ContainsKey(key))
                    {
                        tokens[key] = new List<string>();
                    }
                    tokens[key].Add(value);
                }

                foreach (var token in tokens)
                {
                    sb.Append($"{token.Key}=[{string.Join(", ", token.Value)}]");
                }
                sb.AppendLine();

                input = Console.ReadLine();
            }

            sb.Length -= 2;
            Console.WriteLine(sb);

        }
    }
}
