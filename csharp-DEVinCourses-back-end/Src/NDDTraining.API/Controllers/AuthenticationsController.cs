using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Services.Security;

namespace NDDTraining.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationsController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult VerifyLogin(
            [FromBody] LoginDTO loginDTO
        )
        {
            string token = _userService.VerifyLogin(loginDTO);

            return Ok(token);
        }

    }
}
