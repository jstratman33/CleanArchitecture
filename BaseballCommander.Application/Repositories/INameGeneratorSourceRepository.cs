using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Application.Repositories
{
    public interface INameGeneratorSourceRepository : IRepository<NameGeneratorSource>
    {
        int Count();
        NameGeneratorSource GetRowByIndex(int index);
    }
}