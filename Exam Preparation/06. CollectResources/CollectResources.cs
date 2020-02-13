using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.CollectResources
{
    public class CollectResources
    {
        public static void Main()
        {
            var pathsCollection = new Dictionary<int, int>();
            var regex = new Regex(@"(stone|gold|wood|food)_{0,1}(\d*)");

            var input = Console.ReadLine().Split(' ');
            var paths = int.Parse(Console.ReadLine());

            for (int i = 1; i <= paths; i++)
            {
                var resources = new Dictionary<string, int>() { { "stone", 0 }, { "gold", 0 }, { "wood", 0 }, { "food", 0 } };

                var startStep = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var start = startStep[0];
                var step = startStep[1];
                var collectionDone = false;

                bool[] takenSpots = new bool[input.Length];


                var currentIndex = (start + step) % input.Length;
                while (!collectionDone)
                {
                    var match = regex.Match(input[currentIndex]);
                    if (match.Success)
                    {
                        if (!takenSpots[currentIndex])
                        {
                            var resource = match.Groups[1].Value;
                            var quantity = input[currentIndex].Split('_').Length > 1 ? int.Parse(match.Groups[2].Value) : 1;
                            resources[resource] += quantity;
                            takenSpots[currentIndex] = true;
                        }
                        else
                        {
                            collectionDone = true;
                        }
                    }
                    currentIndex = (currentIndex + step) % input.Length;
                }

                pathsCollection.Add(i, resources.Values.Sum());
            }

            var max = pathsCollection.Values.Max();
            Console.WriteLine(max);
        }
    }
}
