namespace _12.LittleJohn
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class LittleJohn
    {
        public static void Main()
        {
            int countLargeArrows = 0;
            int countMediumArrows = 0;
            int countSmallArrows = 0;

            var sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();
                sb.Append($" {input}");
            }

            var arrowsMatches = new Regex(@"(>{3}-{5}>{2})|(>{2}-{5}>{1})|(>{1}-{5}>{1})").Matches(sb.ToString());

            foreach (Match match in arrowsMatches)
            {
                if (!string.IsNullOrEmpty(match.Groups[1].Value))
                {
                    countLargeArrows++;
                }
                else if (!string.IsNullOrEmpty(match.Groups[2].Value))
                {
                    countMediumArrows++;
                }
                else if (!string.IsNullOrEmpty(match.Groups[3].Value))
                {
                    countSmallArrows++;
                }
            }

            int encryptedCount = EncryptMessage(countLargeArrows, countMediumArrows, countSmallArrows);

            Console.WriteLine(encryptedCount);
        }

        private static int EncryptMessage(int countLargeArrows, int countMediumArrows, int countSmallArrows)
        {
            int firstDecimalNumber = int.Parse(countSmallArrows.ToString() + countMediumArrows.ToString() +
                                               countLargeArrows.ToString());

            string binary = Convert.ToString(firstDecimalNumber, 2);
            string modifiedBinary = binary + Reverse(binary);

            return Convert.ToInt32(modifiedBinary, 2);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
