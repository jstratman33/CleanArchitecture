using System;
using BaseballCommander.Application.Repositories;
using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly IUserRepository _userRepository;

        public GetUserQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel Execute(Guid id)
        {
            if (id == Guid.Empty) return null;

            var userEntity = _userRepository.GetUser(id);
            if (userEntity == null) return null;

            var user = UserModel.MapFromEntity(userEntity);
            return user;
        }
    }
}