using BaseballCommander.Api.Models;

namespace BaseballCommander.Api.Controllers.Users
{
    public class RegisterUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public UserDto ToUserModel()
        {
            return new UserDto()
            {
                Username = Username,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress
            };
        }
    }
}