    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    namespace _Lab_01.ParkingLot
    {
        public class ParkingLot
        {
            public static void Main()
            {
                var parking = new SortedSet<string>();
                var input = Console.ReadLine();

                while (input != "END")
                {
                    var inputParams = Regex.Split(input, ", ");

                    var direction = inputParams[0];
                    var carNumber = inputParams[1];

                    if (direction == "IN")
                    {
                        parking.Add(carNumber);
                    }
                    else
                    {
                        parking.Remove(carNumber);
                    }

                    input = Console.ReadLine();
                }

                Console.WriteLine(parking.Count > 0 ? string.Join("\n", parking) : "Parking Lot is Empty");
            }
        }
    }
