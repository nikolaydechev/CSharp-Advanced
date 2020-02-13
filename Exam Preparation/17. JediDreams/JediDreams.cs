using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _17.JediDreams
{
    public class JediDreams
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();
            var methods = new Dictionary<string, List<string>>();

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();
                sb.Append(line);
            }

            string parsedText = sb.ToString();

            var methodDeclarationMatches = new Regex(@"static\s+.+?\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(").Matches(sb.ToString());
            
            //string str = parsedText.Substring(parsedText.Length - 1);
            //LAST INDEX OF THE TEXT:
            char lastCharacter = parsedText[parsedText.Length - 1];
            int lastIndex = parsedText.LastIndexOf(lastCharacter);

            for (int i = 0; i < methodDeclarationMatches.Count; i++)
            {
                string currentMethod = methodDeclarationMatches[i].Groups[1].Value;


                var distanceBetweenPartitions = i + 1 <= methodDeclarationMatches.Count - 1
                    ? parsedText.IndexOf(methodDeclarationMatches[i + 1].Groups[0].Value) -
                      (parsedText.IndexOf(methodDeclarationMatches[i].Groups[0].Value) +
                       methodDeclarationMatches[i].Groups[0].Value.Length)
                    : lastIndex - (parsedText.IndexOf(methodDeclarationMatches[i].Groups[0].Value) +
                                   methodDeclarationMatches[i].Groups[0].Value.Length);

                string currentPartition = parsedText
                    .Substring(
                        parsedText.IndexOf(methodDeclarationMatches[i].Groups[0].Value) +
                        methodDeclarationMatches[i].Groups[0].Value.Length,
                        distanceBetweenPartitions);

                if (!methods.ContainsKey(currentPartition))
                {
                    methods[currentMethod] = new List<string>();
                }

                var methodCallMatches = new Regex(@"([a-zA-Z]*[A-Z]+[A-Za-z]*)\s*\(").Matches(currentPartition);
                foreach (Match methodCallMatch in methodCallMatches)
                {
                    methods[currentMethod].Add(methodCallMatch.Groups[1].Value);
                }
            }
            
            //PRINTING RESULTS

            foreach (var method in methods.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(method.Value.Count > 0
                    ? $"{method.Key} -> {method.Value.Count} -> {string.Join(", ", method.Value.OrderBy(x => x))}"
                    : $"{method.Key} -> None");
            }



            ////////// SECOND SOLUTION //////////
            /////////////////////////////////////
             
            //var N = int.Parse(Console.ReadLine());

            //var methods = new Dictionary<string, List<string>>();

            //var initialMethod = string.Empty;

            //var regex = new Regex(@"static\s+.+?\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");
            //var rgx = new Regex(@"([a-zA-Z]*[A-Z]+[A-Za-z]*)\s*\(");

            //for (int i = 0; i < N; i++)
            //{
            //    var line = Console.ReadLine();

            //    if (regex.IsMatch(line))
            //    {
            //        Match methodDeclarationMatch = regex.Match(line);
            //        initialMethod = methodDeclarationMatch.Groups[1].Value;

            //        if (!methods.ContainsKey(initialMethod))
            //        {
            //            methods[initialMethod] = new List<string>();
            //        }
            //    }
            //    else if (rgx.IsMatch(line) && initialMethod != string.Empty)
            //    {
            //        var rgxMatches = rgx.Matches(line);

            //        foreach (Match match in rgxMatches)
            //        {
            //            methods[initialMethod].Add(match.Groups[1].Value);
            //        }
            //    }
            //}


            //foreach (var method in methods.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            //{
            //    Console.WriteLine(method.Value.Count > 0
            //        ? $"{method.Key} -> {method.Value.Count} -> {string.Join(", ", method.Value.OrderBy(x => x))}"
            //        : $"{method.Key} -> None");
            //}
        }
    }
}
