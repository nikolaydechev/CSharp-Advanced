using System;
using System.Linq;

namespace _Lab_03.CountUppercaseWords
{
    public class CountUppercaseWords
    {
        public static void Main()
        {
            Action<string> print = upperCaseWord => Console.WriteLine(upperCaseWord);
            Func<string, bool> func = word => word[0] == word.ToUpper()[0];

            var text =
            Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var word in text)
            {
                if (func(word))
                {
                    print(word);
                }
            }

        }
    }
}
