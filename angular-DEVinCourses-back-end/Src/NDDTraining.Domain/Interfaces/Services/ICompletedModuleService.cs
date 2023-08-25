using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface ICompletedModuleService
    {
        List<CompletedModuleDTO> GetCompletedModules(int traning);
        void CompletarModulo(CompletedModuleDTO completedModuleDTO);
    }
}
