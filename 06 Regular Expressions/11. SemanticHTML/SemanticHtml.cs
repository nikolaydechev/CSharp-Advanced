using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _11.SemanticHTML
{
    public class SemanticHtml
    {
        public static void Main()
        {
            var sb = new StringBuilder();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var closingTag = new Regex("(?:\\s+)*<(?:\\s+)*\\/(?:\\s+)*div(?:\\s+)*>((?:.*?)([a-z]+)(?:.*))")
                    .Match(input);

                var regex =
                    new Regex("<(?:\\s+)*div[\\s+\\>]*(?:.*?)(?:\\s+)*((?:\\s*id(?:\\s+)*=|\\s*class(?:\\s+)*=)(?:\\s+)*\"([a-z]+)\")(?:\\s+)*(?:[^\\>])*(?:\\>)*")
                    .Match(input);

                if (closingTag.Success)
                {
                    
                    var typeOfAttribute = closingTag.Groups[2].Value;
                    var modifiedLine = Regex.Replace(closingTag.Value, "div", typeOfAttribute);
                    modifiedLine = Regex.Replace(modifiedLine, $"{closingTag.Groups[1].Value}", "");
                    sb.AppendLine($"{modifiedLine}");
                }
                else if (regex.Success)
                {
                    var firstToken = regex.Groups[1].Value;
                    var secondToken = regex.Groups[2].Value;

                    var modifiedLine = input;
                    modifiedLine = Regex.Replace(modifiedLine, "div", $@"{regex.Groups[2].Value}" );
                    modifiedLine = Regex.Replace(modifiedLine, $"{regex.Groups[1].Value}", "");
                    modifiedLine = Regex.Replace(modifiedLine, "\\s{2,}", " ");
                    modifiedLine = Regex.Replace(modifiedLine, "\\s*>", ">");
                    sb.AppendLine(modifiedLine);
                }
                else
                {
                    sb.AppendLine(input);
                }

                input = Console.ReadLine();
            }

            sb.Length -= 2;
            Console.WriteLine(sb);
            
        }
    }
}
