using System;
using System.Linq;
using System.Numerics;

namespace _04.ArraySlider
{
    public class ArraySlider
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(BigInteger.Parse).ToArray();

            var input = Console.ReadLine();
            var currentIndex = 0;

            while (input != "stop")
            {
                string[] inputParams = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var offset = int.Parse(inputParams[0]) % inputNumbers.Length;
                var operation = inputParams[1];
                var operand = int.Parse(inputParams[2]);

                if (offset < 0)
                {
                    offset += inputNumbers.Length;
                }

                var position = (offset + currentIndex) % inputNumbers.Length;
                
                inputNumbers[position] = DoOperation(inputNumbers[position], operation, operand);

                currentIndex = position;
                input = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", inputNumbers)}]");
        }

        private static BigInteger DoOperation(BigInteger inputNumber, string operation, int operand)
        {
            BigInteger result = 0;
            switch (operation)
            {
                case "&":
                    result = inputNumber & operand;
                    break;
                case "|":
                    result = inputNumber | operand;
                    break;
                case "^":
                    result = inputNumber ^ operand;
                    break;
                case "+":
                    result = inputNumber + operand;
                    break;
                case "-":
                    result = inputNumber - operand;
                    break;
                case "*":
                    result = inputNumber * operand;
                    break;
                case "/":
                    result = inputNumber / operand;
                    break;
            }
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }
    }
}
