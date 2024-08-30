using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformancePrototypeV2.API.Service.DTOs;
using PerformancePrototypeV2.API.Service.Login;

namespace PerformancePrototypev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = _authService.Authenticate(loginModel);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
