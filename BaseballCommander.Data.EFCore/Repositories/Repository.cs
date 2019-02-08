using System;
using System.Collections.Generic;
using System.Linq;
using BaseballCommander.Application.Repositories;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected BaseballCommanderContext Context { get; }

        public Repository(BaseballCommanderContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToArray();
        }
    }
}