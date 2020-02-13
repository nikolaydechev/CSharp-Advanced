using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    public class PartyReservationFilterModule
    {
        public static void Main()
        {
            var guestList = Console.ReadLine().Split(' ').ToList();
            var commandHistory = new List<string>();

            var input = Console.ReadLine();
            CommandHistory(input, commandHistory);


            foreach (var command in commandHistory)
            {
                string[] commandParams = command.Split(';');
                var filterType = commandParams[0];
                var filterParam = commandParams[1];

                Func<string, bool> func = personName => personName.StartsWith(filterParam);
                Func<string, bool> func1 = personName => personName.EndsWith(filterParam);
                Func<string, bool> func2 = personName => personName.Length == int.Parse(filterParam);
                Func<string, bool> func3 = personName => personName.Contains(filterParam);

                switch (filterType)
                {
                    case "Starts with":
                        guestList = FilterGuests(guestList, func);
                        break;
                    case "Ends with":
                        guestList = FilterGuests(guestList, func1);
                        break;
                    case "Length":
                        guestList = FilterGuests(guestList, func2);
                        break;
                    case "Contains":
                        guestList = FilterGuests(guestList, func3);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", guestList));
        }

        private static List<string> FilterGuests(List<string> guestList, Func<string, bool> func)
        {
            var guests = guestList.Where(x => !func(x)).ToList();

            return guests;
        }

        private static void CommandHistory(string input, List<string> commandHistory)
        {
            while (input != "Print")
            {
                string[] inputParams = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = inputParams[0];
                var filterType = inputParams[1];
                var filterParameter = inputParams[2];

                switch (command)
                {
                    case "Add filter":
                        commandHistory.Add($"{filterType};{filterParameter}");
                        break;
                    case "Remove filter":
                        commandHistory.Remove($"{filterType};{filterParameter}");
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
