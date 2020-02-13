using System;

namespace _Lab_03.ParseTags
{
    public class ParseTags
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var startIndex = input.IndexOf("<upcase>");
            var endIndex = input.IndexOf("</upcase>");
            string result = input;

            while (startIndex != -1)
            {
                endIndex = result.IndexOf("</upcase>");

                if (endIndex == -1) break;

                string upCaseText = result.Substring(startIndex, endIndex + 9 - startIndex);
                var upperText = upCaseText.Replace("<upcase>", "").Replace("</upcase>", "").ToUpper();
                result = result.Replace(upCaseText, upperText);

                startIndex = result.IndexOf("<upcase>");
            }

            Console.WriteLine(result);
        }
    }
}
