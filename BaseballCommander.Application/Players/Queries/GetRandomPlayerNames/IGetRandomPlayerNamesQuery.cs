using BaseballCommander.Application.Players.Models;

namespace BaseballCommander.Application.Players.Queries.GetRandomPlayerNames
{
    public interface IGetRandomPlayerNamesQuery
    {
        PlayerName[] Execute(int count);
    }
}