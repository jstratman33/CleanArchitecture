using System;
using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Queries.GetRandomAge
{
    public class GetRandomAgeQuery : IGetRandomAgeQuery
    {
        public GetRandomAgeQuery()
        {
            
        }

        public int Execute(PlayerStatus status)
        {
            var random = new Random();

            switch (status)
            {
                case PlayerStatus.HighSchool:
                    return random.Next(17, 19);
                case PlayerStatus.College:
                    return random.Next(18, 23);
                case PlayerStatus.FreeAgent:
                    return random.Next(18, 36);
                case PlayerStatus.Acquired:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }
    }
}