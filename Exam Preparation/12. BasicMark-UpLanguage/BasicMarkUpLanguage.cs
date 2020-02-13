using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _12.BasicMark_UpLanguage
{
    public class BasicMarkUpLanguage
    {
        public static void Main()
        {
            var regex = new Regex("<\\s*(inverse|reverse|repeat)\\s+(content|value)\\s*=\\s*\"([^\"]+)\"(?:\\s*(?:content\\s*=\\s*\"([^\"]+))\")*\\s*\\/\\s*>");
            var input = Console.ReadLine();

            var result = new List<string>();
            int lineNumber = 1;

            while (input != "<stop/>")
            {
                var match = regex.Match(input);
                if (match.Success)
                {
                    string content = "";
                    switch (match.Groups[1].Value)
                    {
                        case "inverse":
                            content = ModifyUpperLowerLetter(match.Groups[3].Value);
                            result.Add($"{lineNumber++}. {content}");
                            break;

                        case "reverse":
                            content = Reverse(match.Groups[3].Value);
                            result.Add($"{lineNumber++}. {content}");
                            break;

                        case "repeat":
                            for (int i = 0; i < int.Parse(match.Groups[3].Value); i++)
                            {
                                result.Add($"{lineNumber++}. {match.Groups[4].Value}");
                            }
                            break;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", result));
        }

        private static string ModifyUpperLowerLetter(string secondQuery)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < secondQuery.Length; i++)
            {
                if (char.IsUpper(secondQuery, i))
                    result.Append(char.ToLower(secondQuery[i]));
                else if (char.IsLower(secondQuery, i))
                    result.Append(char.ToUpper(secondQuery[i]));
                else
                    result.Append(secondQuery[i]);
            }
            return result.ToString();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
