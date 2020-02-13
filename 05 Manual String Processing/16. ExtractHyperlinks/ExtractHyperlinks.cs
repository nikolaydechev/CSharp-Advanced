using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16.ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();
            var aTagsLines = new List<string>();

            while (input != "END")
            {
                sb.Append(input + " ");
                input = Console.ReadLine();
            }
            var text = sb.ToString();

            var firstIndex = text.IndexOf("<a");
            var endIndex = text.IndexOf("</a>");

            while (true)
            {
                firstIndex = text.IndexOf("<a");
                endIndex = text.IndexOf("</a>");
                if (firstIndex == -1 || endIndex == -1)
                {
                    break;
                }
                var line = text.Substring(firstIndex, endIndex + 4 - firstIndex);
                aTagsLines.Add(line);
                text = text.Remove(firstIndex, endIndex + 4 - firstIndex);
            }

            var result = new List<string>();

            foreach (var line in aTagsLines)
            {
                var index1 = line.IndexOf(" href");
                var index2 = line.IndexOf(">");
                if (index1 == -1 || index2 == -1)
                {
                    continue;
                }
                var modifiedLine = line.Substring(index1, index2 - index1);
                   
                string[] lineParams = modifiedLine.Split(new[] { '>', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var hrefContent = lineParams[1];
                var index = hrefContent.LastIndexOf(" ");
                if (index > 0)
                {
                    hrefContent = hrefContent.Substring(0, index);
                }
                result.Add(hrefContent.Trim(new []{'"', '\'', ' '}));
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
