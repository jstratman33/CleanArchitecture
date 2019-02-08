using BaseballCommander.Application.Repositories;
using BaseballCommander.Application.Shared.Models;

namespace BaseballCommander.Application.Users.Commands.CreateUser
{
    public class CreateUserRequestValidator
    {
        private readonly IUserRepository _userRepository;

        public CreateUserRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public BaseResponse Validate(CreateUserRequest request)
        {
            var response = new BaseResponse
            {
                IsSuccess = true
            };

            if (request == null)
            {
                response.IsSuccess = false;
                response.Messages.Add("Invalid request.");
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                response.IsSuccess = false;
                response.Messages.Add("Username cannot be empty.");
            }

            var exisitingUserWithSameUsername = _userRepository.GetUser(request.Username);
            if (exisitingUserWithSameUsername != null)
            {
                response.IsSuccess = false;
                response.Messages.Add("Username has already been taken.");
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                response.IsSuccess = false;
                response.Messages.Add("Password cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                response.IsSuccess = false;
                response.Messages.Add("First name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                response.IsSuccess = false;
                response.Messages.Add("Last name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.EmailAddress))
            {
                response.IsSuccess = false;
                response.Messages.Add("Email address cannot be empty.");
            }

            return response;
        }
    }
}
