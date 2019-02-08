using System;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(Guid guid);
        User GetUser(string username);
    }
}