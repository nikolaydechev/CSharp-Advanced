using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _24.CubicMessages
{
    public class CubicMessages
    {
        public static void Main()
        {
            var validMessages = new List<string>();

            var input = Console.ReadLine();
            var msgLength = int.Parse(Console.ReadLine());

            while (true)
            {
                var regex = new Regex($@"^\d+([A-Za-z]{{{msgLength}}})[^A-Za-z]*$").Match(input);
                if (regex.Success)
                {
                    string verificationCode = GetVerificationCode(regex.Groups[1].Value, regex.Groups[0].Value);

                    validMessages.Add(regex.Groups[1].Value + " == " + verificationCode);
                }

                input = Console.ReadLine();
                if (input == "Over!") break;
                msgLength = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", validMessages));
        }

        private static string GetVerificationCode(string message, string value)
        {
            var verificationCode = new StringBuilder();
            var indexes = new List<int>();

            foreach (var character in value)
            {
                int digit;
                bool IsDigit = int.TryParse(character.ToString(), out digit);

                if (IsDigit)
                {
                    indexes.Add(digit);
                }
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                if (indexes[i] >= 0 && indexes[i] < message.Length)
                {
                    verificationCode.Append(message[indexes[i]]);
                }
                else
                {
                    verificationCode.Append(" ");
                }
            }

            return verificationCode.ToString();
        }
    }
}
