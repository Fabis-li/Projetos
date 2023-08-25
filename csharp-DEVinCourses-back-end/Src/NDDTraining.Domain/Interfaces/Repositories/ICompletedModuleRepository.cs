using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Repositories
{
    public interface ICompletedModuleRepository
    {

        public void Insert(CompletedModule completedModule);
        public List<CompletedModule> GetCompletModuleRegistrationsId(int registrationId);

    }
}
