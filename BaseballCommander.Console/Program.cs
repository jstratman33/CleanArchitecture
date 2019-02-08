using System.Linq;
using BaseballCommander.Application.Players.Queries;
using BaseballCommander.Application.Players.Queries.GeneratePlayers;
using BaseballCommander.Data.EFCore;
using BaseballCommander.Data.EFCore.Repositories;
using BaseballCommander.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaseballCommander.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("BaseballCommanderConnection");
            var optionsBuilder = new DbContextOptionsBuilder<BaseballCommanderContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new BaseballCommanderContext(optionsBuilder.Options))
            {
                var repository = new NameGeneratorSourceRepository(context);
                var generatePlayerQuery = new GeneratePlayersQuery(repository);

                var request = new GeneratePlayersRequest
                {
                    NumberOfPlayersToCreate = 30 * 3 * 25 * 2,
                    Situation = PlayerGenerationSituation.LeagueCreation
                };
                var players = generatePlayerQuery.Execute(request).ToArray();
                foreach (var player in players)
                {
                    System.Console.WriteLine(
                        $"{player.FirstName} {player.LastName} | Status: {player.Status} | Position: {player.GeneralPosition} | Age: {player.Age}");
                }

                System.Console.WriteLine(
                    $"FreeAgents: {players.Count(x => x.Status == PlayerStatus.FreeAgent)} | College: {players.Count(x => x.Status == PlayerStatus.College)} | HighSchool: {players.Count(x => x.Status == PlayerStatus.HighSchool)}");
                System.Console.WriteLine(
                    $"Pitchers: {players.Count(x => x.GeneralPosition == GeneralPosition.Pitcher)} | Catchers: {players.Count(x => x.GeneralPosition == GeneralPosition.Catcher)} | Position: {players.Count(x => x.GeneralPosition == GeneralPosition.Position)}");
            }

            System.Console.ReadKey();
        }
    }
}
