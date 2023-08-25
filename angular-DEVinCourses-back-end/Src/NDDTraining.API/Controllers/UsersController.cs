
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Services;
using System.Security.Claims;

namespace NDDTraining.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UsersController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;

        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(
            [FromBody] UserDTO changedUser,
            [FromRoute] int id
        )
        {
            if (_userService.InvalidSize(changedUser.Image))
            {
                changedUser.Image = String.Empty;
            }
            _userService.Update(changedUser, id);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] UserDTO newUser
        )
        {
            if (_userService.InvalidSize(newUser.Image))
            {
                newUser.Image = String.Empty;
            }
            _userService.InsertUser(newUser);
            return Created("registration", newUser.Id);
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetUser()

        {
            var email = HttpContext.User.Claims.First(X => X.Type == ClaimTypes.Email).Value;

            return Ok(_userService.GetUser(email));
        }


        [HttpPost]
        [Route("reset")]
        public IActionResult Reset([FromBody] string emailReset)
        {
            var reset = _userService.Reset(emailReset);

            return Ok(reset);
        }

        [HttpPost]
        [Route("token")]
        public IActionResult VerifyToken([FromBody] ResetDTO resetDTO)
        {
            var reset = _userService.VerifyToken(resetDTO);

            return Ok(reset);
        }
    }
}