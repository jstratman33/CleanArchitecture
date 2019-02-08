using BaseballCommander.Application.Players.Models;

namespace BaseballCommander.Application.Players.Queries.GeneratePlayers
{
    public interface IGeneratePlayersQuery
    {
        PlayerModel[] Execute(GeneratePlayersRequest request);
    }
}