using System;
using System.Text.RegularExpressions;

namespace _06.SentenceЕxtractor
{
    public class SentenceExtractor
    {
        public static void Main()
        {
            var keyword = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex($@"[^\!\?\.]*(\s{keyword}\s)[^\!\?\.]*[\!\?\.]").Matches(text);

            for (int i = 0; i < regex.Count; i++)
            {
                Console.WriteLine(regex[i].Value.Trim());
            }
        }
    }
}
