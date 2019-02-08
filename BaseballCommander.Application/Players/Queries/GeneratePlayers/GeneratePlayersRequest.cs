using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Queries.GeneratePlayers
{
    public class GeneratePlayersRequest
    {
        public int NumberOfPlayersToCreate { get; set; }
        public PlayerGenerationSituation Situation { get; set; }
    }
}