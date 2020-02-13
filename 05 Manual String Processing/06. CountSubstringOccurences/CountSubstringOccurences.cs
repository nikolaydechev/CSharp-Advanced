using System;

namespace _06.CountSubstringOccurences
{
    class CountSubstringOccurences
    {
        static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var wordPattern = Console.ReadLine().ToLower();

            var count = 0;
            var index = 0;

            while (true)
            {
                var found = text.IndexOf(wordPattern, index);

                if (found >= 0)
                {
                    count++;
                    index = found + 1;
                }
                if (found == -1)
                {
                    break;
                }
            }
            
            Console.WriteLine(count);
        }
    }
}
