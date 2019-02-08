using System.Linq;
using BaseballCommander.Application.Repositories;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class NameGeneratorSourceRepository : Repository<NameGeneratorSource>, INameGeneratorSourceRepository
    {
        public NameGeneratorSourceRepository(BaseballCommanderContext context) : base(context)
        {
        }

        public int Count()
        {
            return Context.NameGeneratorSource.Count();
        }

        public NameGeneratorSource GetRowByIndex(int index)
        {
            var row = Context.NameGeneratorSource.Skip(index).First();
            return row;
        }
    }
}