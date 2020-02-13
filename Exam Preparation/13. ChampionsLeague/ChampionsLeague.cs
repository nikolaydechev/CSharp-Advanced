using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13.ChampionsLeague
{
    public class ChampionsLeague
    {
        public class Team
        {
            public string TeamName { get; set; }

            public int Wins { get; set; }

            public SortedSet<string> Opponents { get; set; }
        }

        public static void Main()
        {
            var teamList = new List<Team>();
            var input = Console.ReadLine();

            while (input != "stop")
            {
                var regex = new Regex(@"([A-Za-z\s]+)\|([A-Za-z\s]+)\|\s*(\d+):(\d+)\s*\|\s*(\d+)\:(\d+)\s*").Match(input);
                var firstTeam = regex.Groups[1].Value.Trim();
                var secondTeam = regex.Groups[2].Value.Trim();
                var firstTeamTotalScore = int.Parse(regex.Groups[3].Value) + int.Parse(regex.Groups[6].Value);
                var secondTeamTotalScore = int.Parse(regex.Groups[4].Value) + int.Parse(regex.Groups[5].Value);
                var winner = firstTeamTotalScore > secondTeamTotalScore ? firstTeam : secondTeam;
                winner = firstTeamTotalScore == secondTeamTotalScore
                    ? winner = int.Parse(regex.Groups[6].Value) > int.Parse(regex.Groups[4].Value)
                        ? firstTeam
                        : secondTeam
                    : winner;

                if (teamList.All(x => x.TeamName != firstTeam))
                {
                    var team = new Team();
                    team.TeamName = firstTeam;
                    team.Opponents = new SortedSet<string>();
                    team.Opponents.Add(secondTeam);
                    teamList.Add(team);
                }
                else
                {
                    var currentTeam = teamList.First(x => x.TeamName == firstTeam);
                    if (!currentTeam.Opponents.Contains(secondTeam))
                    {
                        currentTeam.Opponents.Add(secondTeam);
                    }
                }

                if (teamList.All(x => x.TeamName != secondTeam))
                {
                    var team = new Team();
                    team.TeamName = secondTeam;
                    team.Opponents = new SortedSet<string>();
                    team.Opponents.Add(firstTeam);
                    teamList.Add(team);
                }
                else
                {
                    var currentTeam = teamList.First(x => x.TeamName == secondTeam);
                    if (!currentTeam.Opponents.Contains(firstTeam))
                    {
                        currentTeam.Opponents.Add(firstTeam);
                    }
                }

                var currentWinner = teamList.First(x => x.TeamName == winner);
                currentWinner.Wins++;

                input = Console.ReadLine();
            }

            foreach (var team in teamList.OrderByDescending(x => x.Wins).ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- Wins: {team.Wins}");
                Console.WriteLine($"- Opponents: {string.Join(", ", team.Opponents)}");
            }
        }
    }
}
