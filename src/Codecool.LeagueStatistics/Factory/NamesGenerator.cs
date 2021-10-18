using System;
using System.IO;

namespace Codecool.LeagueStatistics.Facotry
{
    /// <summary>
    ///     Provides random names for Players and Teams
    /// </summary>
    public static class NamesGenerator
    {
        public static string pathPlayersNames = @"C:\Users\gbszg\source\repos\Codecool\advanced\transition-week\league-statistics-csharp-gabriellaszigeti\data\PlayerNames.txt";
        public static string pathCitiesNames = @"C:\Users\gbszg\source\repos\Codecool\advanced\transition-week\league-statistics-csharp-gabriellaszigeti\data\CityNames.txt";
        public static string pathTeamNames = @"C:\Users\gbszg\source\repos\Codecool\advanced\transition-week\league-statistics-csharp-gabriellaszigeti\data\TeamNames.txt";

        public static string GetPlayerName()
        {
            return File.ReadAllLines(pathPlayersNames).GetRandomValue();
        }

        public static string GetTeamName()
        {
            var cities = File.ReadAllLines(pathCitiesNames);
            var names = File.ReadAllLines(pathTeamNames);

            return cities.GetRandomValue() + " " + names.GetRandomValue();
        }

        public static int GetRandomValue()
        {
            var random = new Random();
            return random.Next(1, 75);
        }
    }
}
