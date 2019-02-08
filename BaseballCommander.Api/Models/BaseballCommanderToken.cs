using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BaseballCommander.Application.Users.Models;
using Microsoft.IdentityModel.Tokens;

namespace BaseballCommander.Api.Models
{
    public class BaseballCommanderToken
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly SecurityToken _token;

        public BaseballCommanderToken(string secret, UserModel userModel)
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userModel.Guid.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            _token = _tokenHandler.CreateToken(tokenDescriptor);
        }

        public string WriteToken()
        {
            return _tokenHandler.WriteToken(_token);
        }
    }
}