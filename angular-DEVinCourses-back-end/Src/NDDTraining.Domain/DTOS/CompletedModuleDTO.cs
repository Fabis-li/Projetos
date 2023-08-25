using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.DTOS
{
    public  class CompletedModuleDTO
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int RegistrationId { get; set; }

        public CompletedModuleDTO()
        {

        }
        public CompletedModuleDTO(CompletedModule completedModule)
        {
            Id = completedModule.Id;
            ModuleId = completedModule.ModuleId;
            RegistrationId = completedModule.RegistrationId;
        }
    }
}
