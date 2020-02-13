using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.UseYourChainsBuddy
{
    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            var result = new StringBuilder();
            var input = Console.ReadLine();
            var regex = new Regex(@"<p>(.*?)<\/p>").Matches(input);

            foreach (Match match in regex)
            {
                var modifiedMatch = DecryptMessage(match.Groups[1].Value);
                result.Append(modifiedMatch);
            }

            Console.WriteLine(result);
        }

        private static string DecryptMessage(string match)
        {
            var result = Regex.Replace(match, @"[^a-z0-9]", " ");
            var sb = new StringBuilder();

            foreach (char character in result)
            {
                if (character >= 'a' && character <= 'm')
                {
                    sb.Append((char)(character + 13));
                }
                else if (character >= 'n' && character <= 'z')
                {
                    sb.Append((char)(character - 13));
                }
                else
                {
                    sb.Append(character);
                }
            }

            return Regex.Replace(sb.ToString(), @"\s+", " ");
        }
    }
}
