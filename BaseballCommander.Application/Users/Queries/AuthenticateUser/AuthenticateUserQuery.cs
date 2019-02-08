using System.Collections.Generic;
using BaseballCommander.Application.Repositories;
using BaseballCommander.Application.Shared.Models;
using BaseballCommander.Application.Users.Models;
using BaseballCommander.Domain.ValueObjects;

namespace BaseballCommander.Application.Users.Queries.AuthenticateUser
{
    public class AuthenticateUserQuery : IAuthenticateUserQuery
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseResponse<UserModel> Execute(AuthenticateUserRequest request)
        {
            var user = _userRepository.GetUser(request.Username);
            var validator = new AuthenticateUserValidator(request, user);
            if (!validator.IsValid)
            {
                return new BaseResponse<UserModel>
                {
                    IsSuccess = false,
                    Messages = validator.Messages
                };
            }

            var password = new Password(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!password.Verify())
            {
                return new BaseResponse<UserModel>
                {
                    IsSuccess = false,
                    Messages = new List<string>
                    {
                        "The username and password combination was incorrect."
                    }
                };
            }

            return new BaseResponse<UserModel>
            {
                IsSuccess = true,
                Messages = new List<string>(),
                Data = UserModel.MapFromEntity(user)
            };
        }
    }
}
