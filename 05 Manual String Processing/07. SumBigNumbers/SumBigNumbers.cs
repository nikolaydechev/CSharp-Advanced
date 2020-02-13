using System;

namespace _07.SumBigNumbers
{
    class SumBigNumbers
    {
        public static void Main()
        {
            var firstNum = Console.ReadLine().TrimStart('0');
            var secondNum = Console.ReadLine().TrimStart('0');

            if (firstNum.Length > secondNum.Length)
            {
                secondNum = secondNum.PadLeft(firstNum.Length, '0');
            }
            else
            {
                firstNum = firstNum.PadLeft(secondNum.Length, '0');
            }

            var result = "";
            bool carry = false;

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                var digit = 0;
                var firstDigit = int.Parse(firstNum.Substring(i, 1));
                var secondDigit = int.Parse(secondNum.Substring(i, 1));
                var sum = firstDigit + secondDigit;
                sum += carry ? 1 : 0;
                carry = false;
                if (sum > 9)
                {
                    digit = sum % 10;
                    carry = true;
                }

                result += sum > 9 ? digit.ToString() : sum.ToString();

                if (i == 0 && sum.ToString().Length > 1)
                {
                    result += sum.ToString().Substring(0, 1);
                }
            }

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);

            Console.WriteLine(new string(charArray));
        }
    }
}
