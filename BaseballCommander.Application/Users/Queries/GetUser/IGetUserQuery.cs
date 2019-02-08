using System;
using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Application.Users.Queries.GetUser
{
    public interface IGetUserQuery
    {
        UserModel Execute(Guid id);
    }
}