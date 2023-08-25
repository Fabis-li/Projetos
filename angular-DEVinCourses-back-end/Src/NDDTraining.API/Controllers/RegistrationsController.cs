using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;


namespace NDDTraining.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]


    public class RegistrationsController : Controller
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationsController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           
                return Ok(_registrationService.GetAll());
           
           
        }

        [HttpGet]
        [Route("~/api/Users/{userId}/Registrations")]
        public IActionResult GetByUser(
            [FromRoute] int userId,
            [FromQuery] string status,
            int skip = 0,
            int take = 20
        )
        {
            var paging = new Paging(skip, take);
            return Ok(_registrationService.GetRegistrationsByUser(userId, status, paging));
        }

        [HttpGet]
        [Route("~/api/Users/{userId}/Registrations/Recents")]
        public IActionResult GetRecentByUser(
                    [FromRoute] int userId
                    // int skip = 0,
                    // int take = 20
                )
        {
            // var paging = new Paging(skip, take);
            return Ok(_registrationService.GetRegistrationsByUserMostRecent(userId));
        }

        [HttpPost]

        public IActionResult Insert(RegistrationDTO registration)
        {

            _registrationService.Insert(registration);
            return StatusCode(StatusCodes.Status201Created);

        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(
         [FromRoute] int Id)
        {          
            _registrationService.Delete(Id);
            return StatusCode(StatusCodes.Status204NoContent);
        }  

        [HttpPatch]
        [Route("~/api/Users/Registrations/{id}")]
        public IActionResult PatchRecentByUser(
                    [FromRoute] int id,
                    [FromBody] long refreshDate
                )
        {   
            _registrationService.Patch(id, refreshDate);
            return Ok();
        }    
    }
}
