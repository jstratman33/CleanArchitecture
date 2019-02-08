using BaseballCommander.Data.EFCore.Configurations;
using BaseballCommander.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballCommander.Data.EFCore
{
    public class BaseballCommanderContext : DbContext
    {
        public BaseballCommanderContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<League> League { get; set; }
        public DbSet<NameGeneratorSource> NameGeneratorSource { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerAttribute> PlayerAttribute { get; set; }
        public DbSet<Roster> Roster { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamPermission> TeamPermission { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}