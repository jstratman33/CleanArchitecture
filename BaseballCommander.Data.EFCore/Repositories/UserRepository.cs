using System;
using System.Linq;
using BaseballCommander.Application.Repositories;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Data.EFCore.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseballCommanderContext context) : base(context)
        {
        }

        public User GetUser(Guid guid)
        {
            return Context.User.FirstOrDefault(x => x.Guid == guid);
        }

        public User GetUser(string username)
        {
            return Context.User.FirstOrDefault(x => x.Username == username);
        }
    }
}