using Codecool.LeagueStatistics.Model;
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
            foreach(var team in sortedTeams)
            {
                Console.WriteLine($"Teams name: {team.Name} , and their scores: {team.CurrentPoints()}, draws: {team.Draws}, looses: {team.Losts}, wins: {team.Wins}.");
            }
        }

        public static void PrintTeamWithLongestName(IEnumerable<Team> teams)
        {
            Team team = Model.LeagueStatistics.GetTeamWithTheLongestName(teams);
                Console.WriteLine($"Team with the longest name : {team.Name}");
            }
        }
    }

