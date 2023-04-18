using HospitalAPI.Security;
using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [EnableCors("InternAllow")]
        [HttpPost("intern/login")]
        public async Task<ActionResult> LoginIntern(LoginRequest loginRequest)
        {
            var token = await _authService.LoginInternAsync(loginRequest);
            if (token == null)
                return BadRequest();
            return Ok(new LoginResponse()
            {
                Jwt = token
            });
        }

        [EnableCors("PublicAllow")]
        [HttpPost("public/login")]
        public async Task<ActionResult> LoginPublic(LoginRequest loginRequest)
        {
            var token = await _authService.LoginPublicAsync(loginRequest);
            if (token == null)
                return BadRequest();
            return Ok(new LoginResponse()
            {
                Jwt = token
            });
        }

        [EnableCors("PublicAllow")]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest registerRequest)
        {
            var ok = await _authService.RegisterAsync(registerRequest);
            if(ok == null)
                return BadRequest();

            return Ok();
        }

        [HttpGet("validate")]
        [Authorize]
        public IActionResult ValidateAuth()
        {
            return Ok();
        }

    }
}
