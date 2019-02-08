using BaseballCommander.Application.Repositories;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class TeamPermissionRepository : Repository<TeamPermission>, ITeamPermissionRepository
    {
        public TeamPermissionRepository(BaseballCommanderContext context) : base(context)
        {
        }
    }
}