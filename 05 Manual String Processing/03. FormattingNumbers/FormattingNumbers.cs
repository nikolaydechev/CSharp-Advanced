using System;

namespace _03.FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main()
        {
            string[] inputParams = Console.ReadLine()
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var a = int.Parse(inputParams[0]);
            var b = double.Parse(inputParams[1]);
            var c = double.Parse(inputParams[2]);

            string result = "|" + a.ToString("X").PadRight(10) + "|";
            result += Convert.ToString(a, 2).PadLeft(10, '0').Substring(0, 10) + "|";
            result += b.ToString("0.00").PadLeft(10) + "|";
            result += c.ToString("0.000").PadRight(10) + "|";

            Console.WriteLine(result);
        }
    }
}
