using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanetGreenTaskAPI.Interfaces;
using PlanetGreenTaskAPI.Models;

namespace PlanetGreenTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService AuthService { get; }
        public AuthController(IAuthService AuthService)
        {
            this.AuthService = AuthService;
        }

        [HttpPost]
        [Route("Authorize")]
        public async Task<IActionResult> Authorize(ExternalLoginModel login)
        {
            return Ok(AuthService.GetToken(login)); 
        }
    }
}
