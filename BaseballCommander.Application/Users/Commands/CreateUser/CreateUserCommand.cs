using System;
using System.Collections.Generic;
using BaseballCommander.Application.Repositories;
using BaseballCommander.Application.Users.Models;
using BaseballCommander.Domain.ValueObjects;

namespace BaseballCommander.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IRepositoryContainer _repositoryContainer;
        private readonly CreateUserRequestValidator _userValidator;

        public CreateUserCommand(IRepositoryContainer repositoryContainer)
        {
            _repositoryContainer = repositoryContainer;
            _userValidator = new CreateUserRequestValidator(_repositoryContainer.User);
        }

        public CreateUserResponse Execute(CreateUserRequest request)
        {
            var validationResponse = _userValidator.Validate(request);
            if (!validationResponse.IsSuccess)
            {
                return new CreateUserResponse
                {
                    IsSuccess = false,
                    Messages = validationResponse.Messages
                };
            }

            try
            {
                var userModel = new UserModel
                {
                    Username = request.Username,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EmailAddress = request.EmailAddress
                };
                var userEntity = userModel.ToEntity();
                userEntity.Guid = Guid.NewGuid();
                userEntity.IsActive = true;

                var password = new Password(request.Password);
                userEntity.PasswordHash = password.Hash;
                userEntity.PasswordSalt = password.Salt;

                _repositoryContainer.User.Create(userEntity);
                _repositoryContainer.SaveChanges();

                var createdUser = _repositoryContainer.User.GetUser(userEntity.Guid);
                return new CreateUserResponse
                {
                    IsSuccess = true,
                    Messages = new List<string>(),
                    User = UserModel.MapFromEntity(createdUser)
            };
            }
            catch (Exception ex)
            {
                return new CreateUserResponse
                {
                    IsSuccess = false,
                    Messages = new List<string>
                    {
                        "A system error has occurred. The problem has been reported."
                    }
                };
            }
        }
    }
}