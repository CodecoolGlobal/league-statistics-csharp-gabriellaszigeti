using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.LeagueStatistics.Factory;
using Codecool.LeagueStatistics.Model;
using Codecool.LeagueStatistics.View;

namespace Codecool.LeagueStatistics.Controllers
{
    /// <summary>
    ///     Provides all necessary methods for season simulation
    /// </summary>
    public class Season
    {
        public List<Team> League { get; set; }
        public Season()
        {
            League = new List<Team>();
        }

        /// <summary>
        ///     Fills league with new teams and simulates all games in season.
        /// After all games played calls table to be displayed.
        /// </summary>
        public void Run()
        {
            var league = LeagueFactory.CreateLeague(6);
            foreach (var team in league)
            {
                League.Add(team);
            }
            PlayAllGames();
            Display.PrintAllTeamsSorted(league);
            Display.PrintTeamWithLongestName(league);
//            Display.PrintAllPlayers(league);
            Display.PrintTeamWithLeastLooses(league,5);
            Display.PrintTeamsWithPlayersWithoutGoals(league);
            Display.PrintPlayersWithAtLeastXGoals(league, 10);
            Display.PrintMostSuccessfullPlayerFromGivenDivision(league, Division.Central);


            // Call Display methods here
        }
        /// <summary>
        ///     Playing one round. Everyone with everyone one time. 
        /// </summary>
        public void PlayAllGames()
        {
            foreach(var team1 in League) { 
                foreach(var team2 in League)
                {
                    if(team1 != team2)
                    PlayMatch(team1, team2);

                }
            }
        }
        /// <summary>
        ///     Plays single game between two teams and displays result after.
        /// </summary>
        public void PlayMatch(Team team1, Team team2)
        {

            int team1goals = ScoredGoals(team1);
            int team2goals = ScoredGoals(team2);

            if (team1goals > team2goals)
            {
                team1.Wins++;
                team2.Losts++;
            }
            else if (team1goals < team2goals)
            {
                team2.Wins++;
                team1.Losts++;
            }
            else
            {
                team1.Draws++;
                team2.Draws++;
            }
        }
     
        /// <summary>
        ///     Checks for each player of given team chanse to score based on skillrate.
        ///     Adds scored golas to player's and team's statistics.
        /// </summary>
        /// <param name="team">team</param>
        /// <returns>All goals scored by the team in current game</returns>
        /// The ScoredGoals() method returns the number of goals scored by a team in one match.
        /// The method contains the logic of the scoring chance of each player.
        /// The method increments the Goals stats of players.

        public int ScoredGoals(Team team)
        {
            var random = new Random(); ;

            var chance = random.Next(1, 50);
            var scores = 0;
            foreach (var player in team.Players)
            {
                if (player.SkillRate >= chance)
                {
                    player.Goals++;
                    scores++;
                }
            }
            team.Wins += scores;
            return scores;
        }
    }
}
