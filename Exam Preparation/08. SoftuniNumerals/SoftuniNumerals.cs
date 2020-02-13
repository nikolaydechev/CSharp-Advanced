using System;
using System.Numerics;

namespace _08.SoftuniNumerals
{
    public class SoftuniNumerals
    {
        public static void Main()
        {
            var inputText = Console.ReadLine();

            string modifiedWord = inputText.Replace("aba", "1");
            modifiedWord = modifiedWord.Replace("aa", "0");
            modifiedWord = modifiedWord.Replace("cdc", "4");
            modifiedWord = modifiedWord.Replace("bcc", "2");
            modifiedWord = modifiedWord.Replace("cc", "3");
            var number = BigInteger.Parse(modifiedWord);

            
        Console.WriteLine(FromBase(number, 5));
        }

        public static BigInteger FromBase(BigInteger value, int @base)
        {
            string number = value.ToString();
            BigInteger n = 1;
            BigInteger r = 0;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                r += n * (number[i] - '0');
                n *= @base;
            }

            return r;
        }
    }
}
