using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Repositories
{
    public interface ITrainingRepository : IBaseRepository<Training, int>
    {
        // IList<Training>GetAll();
        // Training GetById(int id);
        // void Insert (Training training);
        // void Change (Training training);
        // void Delete (Training training);
        Training GetByName(string name);
        bool VerifyExistingName(string title);
        IList<Training> GetActiveTraining();
        IList<Training> GetSuspendedTraining();
        int ObterTotal();
    }
}