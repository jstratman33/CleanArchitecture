using System;
using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Queries.GetRandomGeneralPosition
{
    public class GetRandomGeneralPositionQuery : IGetRandomGeneralPositionQuery
    {
        public GetRandomGeneralPositionQuery()
        {
            
        }

        public GeneralPosition Execute()
        {
            var random = new Random();
            var rng = random.Next(100);
            var pitcherChance = 52;
            var catcherChance = 8;

            if (rng < pitcherChance) return GeneralPosition.Pitcher;
            if (rng < (pitcherChance + catcherChance)) return GeneralPosition.Catcher;
            return GeneralPosition.Position;
        }
    }
}