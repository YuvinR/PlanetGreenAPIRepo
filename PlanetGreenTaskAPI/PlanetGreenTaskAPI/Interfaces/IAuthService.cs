using Microsoft.AspNetCore.Mvc;
using PlanetGreenTaskAPI.Models;

namespace PlanetGreenTaskAPI.Interfaces
{
    public interface IAuthService
    {
        public string GetToken(ExternalLoginModel login);
       
    }
}
