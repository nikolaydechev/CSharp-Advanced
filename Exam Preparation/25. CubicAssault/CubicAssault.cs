using System;
using System.Collections.Generic;
using System.Linq;

namespace _25.CubicAssault
{
    public class CubicAssault
    {
        public class Region
        {
            public string RegionName { get; set; }
            public Dictionary<string, long> MeteorType { get; set; }
        }

        public static void Main()
        {
            var regionList = new List<Region>();

            var input = Console.ReadLine();

            while (input != "Count em all")
            {
                string[] inputParams = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var regionName = inputParams[0];
                var meteorType = inputParams[1];
                var soldiersCount = long.Parse(inputParams[2]);

                if (regionList.All(x => x.RegionName != regionName))
                {
                    var region = new Region();
                    region.RegionName = regionName;
                    region.MeteorType = new Dictionary<string, long>();
                    region.MeteorType["Black"] = 0;
                    region.MeteorType["Red"] = 0;
                    region.MeteorType["Green"] = 0;
                    regionList.Add(region);
                }

                var currentRegion = regionList.First(x => x.RegionName == regionName);
                switch (meteorType)
                {
                    case "Black":
                        currentRegion.MeteorType["Black"] += soldiersCount;
                        break;
                    case "Red":
                        currentRegion.MeteorType["Red"] += soldiersCount;
                        CombineCount(currentRegion);
                        break;
                    case "Green":
                        currentRegion.MeteorType["Green"] += soldiersCount;
                        if (currentRegion.MeteorType["Green"] >= 1000000)
                        {
                            var greenCount = currentRegion.MeteorType["Green"];
                            var numberForRed2 = int.Parse(greenCount.ToString()
                                .Substring(0, greenCount.ToString().Length - 6));
                            var numberForGreen = int.Parse(numberForRed2 + "000000");

                            currentRegion.MeteorType["Red"] += numberForRed2;
                            CombineCount(currentRegion);

                            currentRegion.MeteorType["Green"] -= numberForGreen;
                        }
                        break;
                }
                
                input = Console.ReadLine();
            }

            var orderedRegions = regionList
                .OrderByDescending(x => x.MeteorType["Black"])
                .ThenBy(x => x.RegionName.Length)
                .ThenBy(x => x.RegionName);

            foreach (var orderedRegion in orderedRegions)
            {
                Console.WriteLine($"{orderedRegion.RegionName}");
                foreach (var meteor in orderedRegion.MeteorType.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }

        private static void CombineCount(Region currentRegion)
        {
            if (currentRegion.MeteorType["Red"] >= 1000000)
            {
                var redCount = currentRegion.MeteorType["Red"];
                var numberForBlack = int.Parse(redCount.ToString()
                        .Substring(0, redCount.ToString().Length - 6));
                var numberForRed1 = int.Parse(numberForBlack + "000000");
                currentRegion.MeteorType["Black"] += numberForBlack;
                currentRegion.MeteorType["Red"] -= numberForRed1;
            }
        }
    }
}
