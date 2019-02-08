using BaseballCommander.Api.Models;
using BaseballCommander.Api.Shared;

namespace BaseballCommander.Api.Controllers.Users
{
    public class RegisterUserResponse : ControllerResponse<UserDto>
    {
        public UserDto User { get; set; }
    }
}
