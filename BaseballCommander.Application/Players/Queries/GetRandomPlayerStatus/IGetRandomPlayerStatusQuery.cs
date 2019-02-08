using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Queries.GetRandomPlayerStatus
{
    public interface IGetRandomPlayerStatusQuery
    {
        PlayerStatus Execute(PlayerGenerationSituation situation);
    }
}