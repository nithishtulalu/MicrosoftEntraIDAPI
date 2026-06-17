using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftEntraIDAPI.Services;

namespace MicrosoftEntraIDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result= await _service.Register(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult>Login(LoginDto dto)
        {
            try
            {
                var result = await _service.Login(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
