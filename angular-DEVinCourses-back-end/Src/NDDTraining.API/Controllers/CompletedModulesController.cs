using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDDTraining.API.Controllers;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Services;

namespace NDDTraining.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CompletedModulesController : ControllerBase
    {
        private readonly ICompletedModuleService _completedmoduleService;

        public CompletedModulesController(ICompletedModuleService completedmoduleService)
        {
            _completedmoduleService = completedmoduleService;
        }

        [HttpPost]
        public IActionResult InserirCompletedModule(
         [FromBody] CompletedModuleDTO completedModuleDTO)
        {
            _completedmoduleService.CompletarModulo(completedModuleDTO);
            return Created("completedModule", completedModuleDTO);
        }

        [HttpGet]
        public IActionResult GetCompletedModules(int id)
        {
            return Ok(_completedmoduleService.GetCompletedModules(id));
        }
    }
}

