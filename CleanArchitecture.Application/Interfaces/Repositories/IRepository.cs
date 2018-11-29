using System.Collections.Generic;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
    }
}