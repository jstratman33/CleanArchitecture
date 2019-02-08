using System;
using System.Collections.Generic;
using BaseballCommander.Api.Models;
using BaseballCommander.Api.Shared;
using BaseballCommander.Application.Users;
using BaseballCommander.Application.Users.Commands.CreateUser;
using BaseballCommander.Application.Users.Queries.AuthenticateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BaseballCommander.Api.Controllers.Users
{
    [Authorize]
    [Route("api/v1/users")]
    public class UsersController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IAuthenticateUserQuery _authenticateUserQuery;

        public UsersController(
            IOptions<AppSettings> appSettings,
            ICreateUserCommand createUserCommand,
            IAuthenticateUserQuery authenticateUserQuery)
        {
            _appSettings = appSettings.Value;
            _createUserCommand = createUserCommand;
            _authenticateUserQuery = authenticateUserQuery;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateUserRequest request)
        {
            try
            {
                var authenticateUserResponse = _authenticateUserQuery.Execute(request);

                if (!authenticateUserResponse.IsSuccess)
                {
                    return BadRequest(new ControllerResponse
                    {
                        IsSuccess = false,
                        Messages = authenticateUserResponse.Messages
                    });
                }

                var user = authenticateUserResponse.Data;
                var token = new BaseballCommanderToken(_appSettings.Secret, user);
                var tokenString = token.WriteToken();

                var userDto = UserDto.MapFromBusinessObject(user);
                userDto.Token = tokenString;
                return Ok(new ControllerResponse<UserDto>
                {
                    IsSuccess = true,
                    Messages = authenticateUserResponse.Messages,
                    Data = userDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ControllerResponse
                {
                    IsSuccess = false,
                    Messages = new List<string>
                    {
                        "A system error occurred. The problem has been reported."
                    }
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(CreateUserRequest request)
        {
            try
            {
                var createUserResponse = _createUserCommand.Execute(request);

                if (!createUserResponse.IsSuccess)
                {
                    return BadRequest(new ControllerResponse
                    {
                        IsSuccess = false,
                        Messages = createUserResponse.Messages
                    });
                }

                return Ok(new ControllerResponse<UserDto>
                {
                    IsSuccess = true,
                    Messages = createUserResponse.Messages,
                    Data = UserDto.MapFromBusinessObject(createUserResponse.User)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ControllerResponse
                {
                    IsSuccess = false,
                    Messages = new List<string>
                    {
                        "A system error occurred. The problem has been reported."
                    }
                });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var users = _userProcessor.GetAll();
            //var userDtos = _mapper.Map<IList<UserDto>>(users);
            //return Ok(userDtos);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var user = _userProcessor.GetById(id);
            //var userDto = _mapper.Map<UserDto>(user);
            //return Ok(userDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserDto userDto)
        {
            //// map dto to entity and set id
            //var user = _mapper.Map<User>(userDto);
            //user.Id = id;

            //try
            //{
            //    // save 
            //    _userProcessor.Update(user, userDto.Password);
            //    return Ok();
            //}
            //catch (AppException ex)
            //{
            //    // return error message if there was an exception
            //    return BadRequest(new { message = ex.Message });
            //}
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //_userProcessor.Delete(id);
            return Ok();
        }
    }
}
