using System;
using System.Text;

namespace _20.NMS
{
    public class NMS
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var result = new StringBuilder();

            var input = Console.ReadLine();
            while (input != "---NMS SEND---")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            var delimiter = Console.ReadLine();
            if (delimiter == "(space)")
            {
                delimiter = " ";
            }

            var text = sb.ToString().ToLower();
            

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i].CompareTo(text[i + 1]) <= 0)
                {
                    result.Append(sb[i]);
                }
                else
                {
                    result.Append(sb[i]);
                    result.Append(delimiter);
                }
            }

            result.Append(sb[sb.Length - 1]);

            Console.WriteLine(result);
        }
    }
}
