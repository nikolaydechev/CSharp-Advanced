using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Queue<GasPump> pumps = new Queue<GasPump>();

            for (int i = 0; i < n; i++)
            {
                int[] petrolPumps = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var distanceToNext = petrolPumps[1];
                var amountOfGas = petrolPumps[0];

                GasPump pump = new GasPump(distanceToNext, amountOfGas, i);
                pumps.Enqueue(pump);
            }

            GasPump starterPump = null;
            bool completeJourney = false;

            while (true)
            {
                var currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);

                starterPump = currentPump;
                int gasInTank = currentPump.amountOfGas;

                while (gasInTank >= currentPump.distanceToNext)
                {
                    gasInTank -= currentPump.distanceToNext;

                    currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);

                    if (currentPump == starterPump)
                    {
                        completeJourney = true;
                        break;
                    }

                    gasInTank += currentPump.amountOfGas;

                }
                if (completeJourney)
                {
                    Console.WriteLine(starterPump.indexOfPump);
                    break;
                }
            }
        }

        public class GasPump
        {
            public int distanceToNext;
            public int amountOfGas;
            public int indexOfPump;

            public GasPump(int distanceToNext, int amountOfGas, int indexOfPump)
            {
                this.distanceToNext = distanceToNext;
                this.amountOfGas = amountOfGas;
                this.indexOfPump = indexOfPump;
            }
        }
    }
}
