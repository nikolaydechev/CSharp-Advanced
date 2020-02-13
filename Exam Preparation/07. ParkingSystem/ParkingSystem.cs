using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ParkingSystem
{
    public class ParkingSystem
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split();
            var r = int.Parse(dimensions[0]);
            var c = int.Parse(dimensions[1]);

            var coordinates = new HashSet<string>();

            var result = new List<string>();
            var input = Console.ReadLine();

            while (input != "stop")
            {
                var inputParams = input.Split().Select(int.Parse).ToArray();
                var entryRow = inputParams[0];
                var parkingRow = inputParams[1];
                var parkingCol = inputParams[2];

                var foundSpot = false;
                var count = entryRow == parkingRow ? 1 : Math.Abs(parkingRow - entryRow) + 1;

                if (!coordinates.Contains($"{parkingRow} - {parkingCol}"))
                {
                    coordinates.Add($"{parkingRow} - {parkingCol}");
                    count += parkingCol;
                    foundSpot = true;
                }
                else
                {
                    var currentCol = 0;
                    var bestLength = int.MaxValue;
                    for (int col = 1; col < c; col++)
                    {
                        int currentLength = Math.Abs(parkingCol - col);
                        if (!coordinates.Contains($"{parkingRow} - {col}"))
                        {
                            if (currentLength < bestLength)
                            {
                                bestLength = currentLength;
                                currentCol = col;
                            }
                        }
                    }

                    if (currentCol > 0)
                    {
                        coordinates.Add($"{parkingRow} - {currentCol}");
                        count += currentCol;
                        foundSpot = true;
                    }

                }

                result.Add(foundSpot ? $"{count}" : $"Row {parkingRow} full");

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}

