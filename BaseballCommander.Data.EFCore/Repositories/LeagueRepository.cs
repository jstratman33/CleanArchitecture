using BaseballCommander.Application.Repositories;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class LeagueRepository : Repository<League>, ILeagueRepository
    {
        public LeagueRepository(BaseballCommanderContext context) : base(context)
        {
        }
    }
}