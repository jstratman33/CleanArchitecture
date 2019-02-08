using BaseballCommander.Data.EFCore;
using BaseballCommander.Data.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballCommander.Domain.Tests
{
    public class BaseTest
    {
        protected readonly RepositoryContainer RepositoryContainer;

        public BaseTest()
        {
            const string connectionString = "Server=(localdb)\\mssqllocaldb; Database=BaseballCommander; Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<BaseballCommanderContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var context = new BaseballCommanderContext(optionsBuilder.Options);
            RepositoryContainer = new RepositoryContainer(context);
        }
    }
}