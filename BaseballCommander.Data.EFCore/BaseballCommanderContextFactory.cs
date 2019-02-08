using Microsoft.EntityFrameworkCore;

namespace BaseballCommander.Data.EFCore
{
    public class BaseballCommanderContextFactory : DesignTimeDbContextFactoryBase<BaseballCommanderContext>
    {
        protected override BaseballCommanderContext CreateNewInstance(DbContextOptions<BaseballCommanderContext> options)
        {
            return new BaseballCommanderContext(options);
        }
    }
}