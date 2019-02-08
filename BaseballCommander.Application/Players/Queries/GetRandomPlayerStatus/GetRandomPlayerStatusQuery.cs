using System;
using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Queries.GetRandomPlayerStatus
{
    public class GetRandomPlayerStatusQuery : IGetRandomPlayerStatusQuery
    {
        public GetRandomPlayerStatusQuery()
        {
            
        }

        public PlayerStatus Execute(PlayerGenerationSituation situation)
        {
            var random = new Random();
            var rng = random.Next(100);
            var freeAgentChance = 0;
            var collegeChance = 0;

            switch (situation)
            {
                case PlayerGenerationSituation.LeagueCreation:
                    freeAgentChance = 70;
                    collegeChance = 20;
                    break;
                case PlayerGenerationSituation.ProspectDraft:
                    freeAgentChance = 0;
                    collegeChance = 50;
                    break;
                case PlayerGenerationSituation.FreeAgency:
                    freeAgentChance = 100;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(situation), situation, null);
            }

            if (rng < freeAgentChance) return PlayerStatus.FreeAgent;
            if (rng < (freeAgentChance + collegeChance)) return PlayerStatus.College;
            return PlayerStatus.HighSchool;
        }
    }
}