using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Queries.GetRandomGeneralPosition
{
    public interface IGetRandomGeneralPositionQuery
    {
        GeneralPosition Execute();
    }
}