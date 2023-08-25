//using NDDTraining.Domain.Interfaces.Repositories;
//using NDDTraining.Domain.Models;
//using NDDTraining.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Infra.Data.Repository
{
    namespace NDDTraining.Infra.Data.Repository
    {
        public class CompletedModuleRepository : BaseRepository<CompletedModule, int>, ICompletedModuleRepository
        {

            public CompletedModuleRepository(NDDTrainingDbContext context) : base(context)
            {
            }

            public List<CompletedModule> GetCompletModuleRegistrationsId(int registrationId)
            {
                return _context.CompletedModule.Where(m => m.RegistrationId == registrationId).ToList();
            }
        }
    }
}

