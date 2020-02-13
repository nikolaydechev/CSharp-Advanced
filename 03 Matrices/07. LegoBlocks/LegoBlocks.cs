using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.LegoBlocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var n = int.Parse(Console.ReadLine());
            var firstJagged = new List<List<int>>(n);
            var secondJagged = new List<List<int>>(n);

            for (int rowsIndex = 0; rowsIndex < n; rowsIndex++)
            {
                var subList = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse).ToList();
                firstJagged.Add(subList);
            }
            for (int rowsIndex = 0; rowsIndex < n; rowsIndex++)
            {
                var subList = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).Reverse().ToList();
                secondJagged.Add(subList);
            }

            var newList = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                var list = firstJagged[i].Concat(secondJagged[i]).ToList();
                newList.Add(list);
            }

            var rowCount = newList[0].Count;
            var totalRowsCount = 0;
            var matched = true;

            foreach (var row in newList)
            {
                if (row.Count != rowCount)
                {
                    // COUNTING ELEMENTS
                    foreach (var list in newList)
                    {
                        totalRowsCount += list.Count;
                    }
                    Console.WriteLine($"The total number of cells is: {totalRowsCount}");
                    matched = false;
                    break;
                }
            }

            if (matched)
            {
                foreach (var row in newList)
                {
                    Console.WriteLine($"[{string.Join(", ", row)}]");
                }
            }

            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            Console.WriteLine(ts);
            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
