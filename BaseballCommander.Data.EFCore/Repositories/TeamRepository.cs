using BaseballCommander.Application.Repositories;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(BaseballCommanderContext context) : base(context)
        {
        }
    }
}