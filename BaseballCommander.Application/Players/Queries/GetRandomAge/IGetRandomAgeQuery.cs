using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Queries.GetRandomAge
{
    public interface IGetRandomAgeQuery
    {
        int Execute(PlayerStatus status);
    }
}