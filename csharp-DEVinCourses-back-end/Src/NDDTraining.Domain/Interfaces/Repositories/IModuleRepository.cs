using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Repositories
{
    public interface IModuleRepository : IBaseRepository<Module, int>
    {
        // IList<Module>GetAll();
        IList<Module>GetByTraining(int trainingId);
        // void Insert (Module module);
        // void Change (Module module);
        // void Delete (Module module);
    }
}
