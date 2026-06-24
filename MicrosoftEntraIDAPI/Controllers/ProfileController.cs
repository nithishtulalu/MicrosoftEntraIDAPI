using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicrosoftEntraIDAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "AzureAd")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Profile()
        {
            return Ok(new
            {
                Name = User.Identity?.Name,
                Email = User.Claims.FirstOrDefault(c =>
                    c.Type.Contains("preferred_username"))?.Value
            });
        }
    }
}
