using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        CreateUserResponse Execute(CreateUserRequest request);
    }
}