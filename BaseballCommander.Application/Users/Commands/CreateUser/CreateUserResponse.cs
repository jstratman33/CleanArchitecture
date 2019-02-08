using BaseballCommander.Application.Shared.Models;
using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Application.Users.Commands.CreateUser
{
    public class CreateUserResponse : BaseResponse
    {
        public UserModel User { get; set; }
    }
}