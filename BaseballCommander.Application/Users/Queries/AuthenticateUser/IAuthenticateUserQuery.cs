using BaseballCommander.Application.Shared.Models;
using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Application.Users.Queries.AuthenticateUser
{
    public interface IAuthenticateUserQuery
    {
        BaseResponse<UserModel> Execute(AuthenticateUserRequest request);
    }
}