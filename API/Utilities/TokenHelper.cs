using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace API.Utilities
{
    public class TokenHelper
    {
        public string CreateToken(User user){
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret key secret key"));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var token = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signInCredentials
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var createToken = TokenHandler.CreateToken(token);
            return TokenHandler.WriteToken(createToken);
        }
    }
}