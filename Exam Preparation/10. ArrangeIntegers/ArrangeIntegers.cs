using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10.ArrangeIntegers
{
    public class ArrangeIntegers
    {
        public static void Main()
        {
            var inputNumbers =
                Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var numbersInText = new Dictionary<int, string>()
            {
                {0, "zero"},
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"}
            };

            var result = new List<string>();

            foreach (var number in inputNumbers)
            {
                var regex = new Regex(@"\d").Matches(number);
                var currentNumber = "";
                foreach (Match match in regex)
                {
                    if (numbersInText.ContainsKey(int.Parse(match.Value)))
                    {
                        currentNumber += numbersInText[int.Parse(match.Value)] + "-";
                    }
                }
                result.Add(currentNumber.Trim('-'));
            }


            var orderedResult = result.OrderBy(x => x).OrderBy(y => y.Split('-').Length).OrderBy(z => z);
            var finalResult = new List<string>();

            foreach (var number in orderedResult)
            {
                var regex = new Regex(@"(one|two|three|four|five|six|seven|eight|nine|zero)").Matches(number);
                var currentNumber = "";
                foreach (Match match in regex)
                {
                    if (numbersInText.ContainsValue(match.Value))
                    {
                        var myKey = numbersInText.FirstOrDefault(x => x.Value == match.Value).Key;
                        currentNumber += myKey;
                    }
                }
                finalResult.Add(currentNumber);
            }


            Console.WriteLine(string.Join(", ", finalResult));


        }
    }
}
