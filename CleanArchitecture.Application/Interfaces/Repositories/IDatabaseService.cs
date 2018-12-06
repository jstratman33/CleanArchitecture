using System;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IDatabaseService : IDisposable
    {
        void SaveChanges();
    }
}