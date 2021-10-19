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

        public static void PrintAllPlayers(IEnumerable<Team> teams)
        {
            IEnumerable<Player> players = Model.LeagueStatistics.GetAllPlayers(teams);
            foreach (var player in players)
            {
                Console.WriteLine($"Name of player : {player.Name}");
            }

        }

        public static void PrintTeamWithLeastLooses(IEnumerable<Team> teams,int teamsNumber)
        {
            IEnumerable<Team> topTeams = Model.LeagueStatistics.GetTopTeamsWithLeastLoses(teams, teamsNumber);
            foreach (var team in topTeams)
            {
                Console.WriteLine($"Name of team : {team.Name}, number of looses : {team.Losts}");
            }

        }

        public static void PrintTeamsWithPlayersWithoutGoals(IEnumerable<Team> teams)
        {
            IEnumerable<Team> teamsWithPlayersWithoutGoals = Model.LeagueStatistics.GetTeamsWithPlayersWithoutGoals(teams);
            foreach (var team in teamsWithPlayersWithoutGoals)
            {
                Console.WriteLine($"Name of team with players without goals : {team.Name}");
            }

        }
        public static void PrintPlayersWithAtLeastXGoals(IEnumerable<Team> teams, int goals)
        {
            IEnumerable<Player> playersWithAtLeastXGoals = Model.LeagueStatistics.GetPlayersWithAtLeastXGoals(teams, goals);
            foreach (var player in playersWithAtLeastXGoals)
            {
                Console.WriteLine($"Name of player: {player.Name}, numbers of goals: {player.Goals}");
            }

        }


    }
    }

