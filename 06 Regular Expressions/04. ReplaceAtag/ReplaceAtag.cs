using System;
using System.Text.RegularExpressions;

namespace _04.ReplaceAtag
{
    public class ReplaceAtag
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"<a\s+href=(.+?)\>(.+)<\/a>");

            while (input != "end")
            {
                input = regex.Replace(input, "[URL href=$1]$2[/URL]");
                Console.WriteLine(input);

                input = Console.ReadLine();
            }
        }
    }
}
