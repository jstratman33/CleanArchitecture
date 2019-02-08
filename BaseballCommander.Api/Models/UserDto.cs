using System;
using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Api.Models
{
    public class UserDto
    {
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Token { get; set; }

        public UserModel ToBusinessObject()
        {
            return new UserModel
            {
                Guid = Guid,
                Username = Username,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress
            };
        }

        public static UserDto MapFromBusinessObject(UserModel source)
        {
            return new UserDto
            {
                Guid = source.Guid,
                Username = source.Username,
                Password = source.Password,
                FirstName = source.FirstName,
                LastName = source.LastName,
                EmailAddress = source.EmailAddress
            };
        }

    }
}