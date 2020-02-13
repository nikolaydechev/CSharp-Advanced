using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _16.JediCodeX
{
    public class JediCodeX
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();
                sb.Append(line);
            }

            //EXTRACTING JEDI NAMES
            string namePattern = Console.ReadLine();
            var regexJediNames = new Regex($@"{Regex.Escape(namePattern)}([A-Za-z]{{{namePattern.Length}}})(?![A-Za-z])").Matches(sb.ToString());
            var jediNames = new List<string>();
            foreach (Match match in regexJediNames)
            {
                jediNames.Add(match.Groups[1].Value);
            }

            //EXTRACTING JEDI MESSAGES
            string msgPattern = Console.ReadLine();
            var regexJediMessages = new Regex($@"{Regex.Escape(msgPattern)}([A-Za-z0-9]{{{msgPattern.Length}}})(?![A-Za-z0-9])").Matches(sb.ToString());
            var jediMessages = new List<string>();
            foreach (Match match in regexJediMessages)
            {
                jediMessages.Add(match.Groups[1].Value);
            }

            //MATCHING THE RIGHT MESSAGES TO THE RIGHT JEDIS
            var indexesOfMsgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = new List<string>();
            var startingPosition = 0;

            foreach (var jedi in jediNames)
            {
                if (startingPosition > indexesOfMsgs.Length - 1)
                {
                    break;
                }
                for (int i = startingPosition; i < indexesOfMsgs.Length; i++)
                {
                    if (indexesOfMsgs[i] - 1 < jediMessages.Count)
                    {
                        result.Add(jedi + " - " + jediMessages[indexesOfMsgs[i] - 1]);
                        startingPosition = i + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join("\n", result));
            
        }
    }
}
