using System.Collections.Generic;

namespace BaseballCommander.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}