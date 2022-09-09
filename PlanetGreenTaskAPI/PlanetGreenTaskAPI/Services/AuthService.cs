using Microsoft.IdentityModel.Tokens;
using PlanetGreenTaskAPI.Interfaces;
using PlanetGreenTaskAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlanetGreenTaskAPI.Services
{
    public class AuthService : IAuthService
    {
        public IConfiguration Configuration { get; }
        public AuthService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetToken(ExternalLoginModel login)
        {
            var UserName = Configuration["ExternalClients:User:UserName"];
            var Password = Configuration["ExternalClients:User:Password"];
            var TokenExpirationTime = Configuration["TokenExpirationTime"];

            if (UserName == login.UserName && Password == login.Password)
            {
                return GenerateJwtToken(UserName, Int32.Parse(TokenExpirationTime));
            }

            return string.Empty;


        }

        private string GenerateJwtToken(string userName,int TokenExpirationTime)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("KeyoftheexternalAPI");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(TokenExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
