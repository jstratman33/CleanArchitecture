using BaseballCommander.Application.Shared.Models;
using BaseballCommander.Domain.Entities;

namespace BaseballCommander.Application.Users.Queries.AuthenticateUser
{
    public class AuthenticateUserValidator : BaseValidator
    {
        public AuthenticateUserValidator(AuthenticateUserRequest request, User user)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                IsValid = false;
                Messages.Add("Username or password was not provided.");
            }

            if (user == null)
            {
                IsValid = false;
                Messages.Add("The username and password combination was incorrect.");
            }

            if (user != null && !user.IsActive)
            {
                IsValid = false;
                Messages.Add("User is not activated.");
            }
        }
    }
}