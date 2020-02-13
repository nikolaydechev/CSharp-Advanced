using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.SecondNature
{
    public class SecondNature
    {
        public static void Main()
        {
            var secondNatureFlowers = new List<int>();

            var flowersDust = Console.ReadLine().Split().Select(int.Parse).ToList();
            var buckets = Console.ReadLine().Split().Select(int.Parse).ToList();

            var currentFlower = 0;
            var currentBucket = buckets.Count - 1;

            while (currentBucket >= 0 && currentFlower < flowersDust.Count)
            {
                if (buckets[currentBucket] < flowersDust[currentFlower])
                {
                    flowersDust[currentFlower] -= buckets[currentBucket];
                    buckets[currentBucket] = 0;
                    currentBucket--;
                }
                else if (buckets[currentBucket] > flowersDust[currentFlower])
                {
                    buckets[currentBucket] -= flowersDust[currentFlower];
                    flowersDust[currentFlower] = 0;
                    currentFlower++;

                    if (currentBucket > 0)
                    {
                        buckets[currentBucket - 1] += buckets[currentBucket];
                        buckets[currentBucket] = 0;
                        currentBucket--;
                    }
                }
                else
                {
                    secondNatureFlowers.Add(flowersDust[currentFlower]);
                    buckets[currentBucket] = 0;
                    flowersDust[currentFlower] = 0;
                    currentBucket--;
                    currentFlower++;

                }
            }

            flowersDust.RemoveAll(x => x == 0);
            buckets.RemoveAll(x => x == 0);
            if (flowersDust.Count > 0)
            {
                Console.WriteLine(string.Join(" ", flowersDust));
            }
            if (buckets.Count > 0)
            {
                buckets.Reverse();
                Console.WriteLine(string.Join(" ", buckets));
            }
            Console.WriteLine(secondNatureFlowers.Count > 0 ? string.Join(" ", secondNatureFlowers) : "None");
        }
    }
}
