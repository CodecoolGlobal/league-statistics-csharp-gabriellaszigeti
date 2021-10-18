using Codecool.LeagueStatistics.Model;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.View
{
    /// <summary>
    /// Provides console view for league table, results and all League statistics
    /// </summary>
    public static class Display
    {
        public static void PrintAllTeamsSorted(IEnumerable<Team> teams)
        {
            IEnumerable<Team> sortedTeams = Model.LeagueStatistics.GetAllTeamsSorted(teams);
            PrintTable(sortedTeams);

        }

        public static void PrintTeamWithLongestName(IEnumerable<Team> teams)
        {
            Team team = Model.LeagueStatistics.GetTeamWithTheLongestName(teams);
                Console.WriteLine($"Team with the longest name : {team.Name}");
            }

        public static void PrintTable(IEnumerable<Team> teams)
        {;
            var table = new ConsoleTable("name", "points", "wins", "draws", "looses");
            foreach(var team in teams)
            {
                table.AddRow(team.Name, team.CurrentPoints(), team.Wins, team.Draws, team.Losts);
            }
            Console.WriteLine(table);
        }

    }
    }

