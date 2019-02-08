using BaseballCommander.Application.Repositories;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class RepositoryContainer : IRepositoryContainer
    {
        private readonly BaseballCommanderContext _context;
        public ILeagueRepository League { get; }
        public INameGeneratorSourceRepository NameGeneratorSource { get; }
        public IPlayerAttributeRepository PlayerAttribute { get; }
        public IPlayerRepository Player { get; }
        public IRosterRepository Roster { get; }
        public ITeamPermissionRepository TeamPermission { get; }
        public ITeamRepository Team { get; }
        public IUserRepository User { get; }

        public RepositoryContainer(BaseballCommanderContext context)
        {
            _context = context;
            League = new LeagueRepository(_context);
            NameGeneratorSource = new NameGeneratorSourceRepository(_context);
            PlayerAttribute = new PlayerAttributeRepository(_context);
            Player = new PlayerRepository(_context);
            Roster = new RosterRepository(_context);
            TeamPermission = new TeamPermissionRepository(_context);
            Team = new TeamRepository(_context);
            User = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}