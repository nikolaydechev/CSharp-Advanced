using System;

namespace _08.MultiplyBigNumbers
{
    class MultiplyBigNumber
    {
        static void Main()
        {
            var firstNum = Console.ReadLine().TrimStart(new char[] { '0' });
            var secondNum = int.Parse(Console.ReadLine());

            if (firstNum == "0" || secondNum == 0 || firstNum == "")
            {
                Console.WriteLine(0);
                return;
            }

            var result = "";
            var numberInMind = 0;
            var digit = 0;

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                var lastDigit = int.Parse(firstNum.Substring(i, 1));
                var product = (lastDigit * secondNum) + numberInMind;

                if (product > 9)
                {
                    numberInMind = product / 10;
                    digit = product % 10;
                }
                else
                {
                    numberInMind = 0;
                }

                result += product > 9 ? digit.ToString() : product.ToString();

                if (i == 0 && product.ToString().Length > 1)
                {
                    result += product.ToString().Substring(0, 1);
                }
            }
            
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);

            Console.WriteLine(new string(charArray));
        }
    }
}
