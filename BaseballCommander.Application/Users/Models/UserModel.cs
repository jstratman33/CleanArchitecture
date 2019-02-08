using System;
using BaseballCommander.Application.Teams.Models;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Application.Users.Models
{
    public class UserModel
    {
        public UserModel()
        {
            TeamPermissions = new TeamPermissionModel[0];
        }

        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public TeamPermissionModel[] TeamPermissions { get; set; }

        public User ToEntity()
        {
            return new User
            {
                Guid = Guid,
                Username = Username,
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress
            };
        }

        public static UserModel MapFromEntity(User source)
        {
            return new UserModel
            {
                Guid = source.Guid,
                Username = source.Username,
                FirstName = source.FirstName,
                LastName = source.LastName,
                EmailAddress = source.EmailAddress
            };
        }
    }
}