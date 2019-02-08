using BaseballCommander.Application.Repositories;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class PlayerAttributeRepository : Repository<PlayerAttribute>, IPlayerAttributeRepository
    {
        public PlayerAttributeRepository(BaseballCommanderContext context) : base(context)
        {
        }
    }
}