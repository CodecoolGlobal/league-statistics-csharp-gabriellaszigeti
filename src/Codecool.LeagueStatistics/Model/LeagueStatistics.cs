using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.Model
{
    /// <summary>
    ///     Provides all necessary statistics of played season.
    /// </summary>
    public static class LeagueStatistics
    {
        /// <summary>
        ///     Gets all teams with highests points order, if points are equal next deciding parameter is sum of golas of the team.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>

        public static IEnumerable<Team> GetAllTeamsSorted(this IEnumerable<Team> teams) => teams
            .OrderByDescending(team => team.CurrentPoints()).ThenByDescending(team => (team.Players.Sum(player => player.Goals)));


        /// <summary>
        ///     Gets all players from each team in one collection.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>

        public static IEnumerable<Player> GetAllPlayers(this IEnumerable<Team> teams) =>
            from team in teams 
            from players in team.Players 
            select players;


        /// <summary>
        ///     Gets team with the longest name
        /// </summary>
        /// 
        /// <param name="teams"></param>
        /// <returns></returns>

        public static Team GetTeamWithTheLongestName(this IEnumerable<Team> teams) => teams
            .OrderByDescending(team => team.Name.Length)
            .ThenBy(team => team.Players.Sum(player => player.Goals))
            .FirstOrDefault();


        /// <summary>
        ///     Gets top teams with least number of lost matches.
        ///     If the amount of lost matches is equal, next deciding parameter is team's current points value.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="teamsNumber">The number of Teams to select.</param>
        /// <returns>Collection of selected Teams.</returns>

        public static IEnumerable<Team> GetTopTeamsWithLeastLoses(this IEnumerable<Team> teams, int teamsNumber) 
            => teams
            .OrderByDescending(team => team.Losts)
            .Reverse()
            .Take(teamsNumber);


        /// <summary>
        ///     Gets a player with the biggest goals number from each team.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static IEnumerable<Player> GetTopPlayersFromEachTeam(this IEnumerable<Team> teams)
            => teams
            .Select(team => team.Players.OrderBy(player => player.Goals)
            .FirstOrDefault());


        /// <summary>
        ///     Returns the division with greatest amount of points.
        ///     If there is more than one division with the same amount current points, then check the amounts of wins.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>

        public static Division GetStrongestDivision(this IEnumerable<Team> teams)
            => (from team in teams
                orderby team.CurrentPoints() descending, team.Wins descending
                select team.Division).FirstOrDefault();

                
        /// <summary>
        ///     Gests all teams, where there are players with no scored goals.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>

        public static IEnumerable<Team> GetTeamsWithPlayersWithoutGoals(this IEnumerable<Team> teams)
        => from team in teams
           from player in team.Players
           where player.Goals == 0
           select team;


        /// <summary>
        /// Gets players with given or higher number of goals scored.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="goals">The minimal number of golas scored.</param>
        /// <returns>Collection of Players with given or higher number of goals scored.</returns>
        public static IEnumerable<Player> GetPlayersWithAtLeastXGoals(this IEnumerable<Team> teams, int goals)
                        => from team in teams
                           from player in team.Players
                           where player.Goals >= goals
                           select player;


        /// <summary>
        ///     Gets the player with the highest skill rate for given Division.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="division"></param>
        /// <returns></returns>

        
        public static Player GetMostTalentedPlayerInDivision(this IEnumerable<Team> teams, Division division)
            => (Player)(from team in teams
               from player in team.Players
               where team.Division == division
               orderby player.SkillRate descending
               select player).FirstOrDefault();


    }
}
