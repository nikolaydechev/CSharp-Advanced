using System;
using System.Collections.Generic;

namespace _11.ParkingSystem
{
    public class ParkingSystem
    {
        public static void Main()
        {
            var taken = new HashSet<string>();
            var dimensions =
                Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);


            var parkingRow = Console.ReadLine();

            while (!parkingRow.Equals("stop"))
            {
                var rowData =
                    parkingRow.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var startingRow = int.Parse(rowData[0]);
                var x = int.Parse(rowData[1]);
                var y = int.Parse(rowData[2]);

                var coodinates = $"{x}|{y}";

                if (!taken.Contains(coodinates))
                {
                    taken.Add(coodinates);
                    Printing(true, startingRow, x, y);
                }
                else
                {
                    bool found = false;
                    var loops = Math.Max(y - 1, cols - y);
                    var col = 0;

                    for (int i = 1; i < loops; i++)
                    {
                        var left = $"{x}|{y - i}";
                        var right = $"{x}|{y + i}";

                        if (!taken.Contains(left) && y - i > 0)
                        {
                            col = y - i;
                            taken.Add(left);
                            found = true;
                            break;
                        }

                        if (!taken.Contains(right) && y + i < cols)
                        {
                            col = y + i;
                            taken.Add(right);
                            found = true;
                            break;
                        }
                    }

                    Printing(found, startingRow, x, col);
                }

                parkingRow = Console.ReadLine();
            }
        }

        public static int CalculateDistance(int startingRow, int row, int col)
        {
            return Math.Abs(startingRow - row) + col + 1;
        }

        private static void Printing(bool found, int startingRow, int row, int col)
        {
            if (found)
            {
                int distance = CalculateDistance(startingRow, row, col);
                Console.WriteLine(distance);
            }
            else
            {
                Console.WriteLine("Row {0} full", row);
            }
        }


        
    }
}
