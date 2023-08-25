using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;

namespace NDDTraining.Infra.Data.Repository
{
    public class
    ModuleRepository
    : BaseRepository<Module, int>, IModuleRepository
    {
        public ModuleRepository(NDDTrainingDbContext context) :
            base(context)
        {
        }

        public IList<Module> GetByTraining(int trainingId)
        {
            return _context.Modules.Where(x => x.TrainingId == trainingId).ToList();
        }
    }
}
