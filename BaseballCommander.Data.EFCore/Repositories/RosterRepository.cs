using BaseballCommander.Application.Repositories;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class RosterRepository : Repository<Roster>, IRosterRepository
    {
        public RosterRepository(BaseballCommanderContext context) : base(context)
        {
        }
    }
}