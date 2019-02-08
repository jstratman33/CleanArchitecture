using System;

namespace BaseballCommander.Application.Repositories
{
    public interface IRepositoryContainer : IDisposable
    {
        ILeagueRepository League { get; }
        INameGeneratorSourceRepository NameGeneratorSource { get; }
        IPlayerAttributeRepository PlayerAttribute { get; }
        IPlayerRepository Player { get; }
        IRosterRepository Roster { get; }
        ITeamPermissionRepository TeamPermission { get; }
        ITeamRepository Team { get; }
        IUserRepository User { get; }
        int SaveChanges();
    }
}