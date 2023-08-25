using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using NDDTraining.Domain.Interfaces.Repositories;

namespace NDDTraining.Infra.Data.Repository
{
    public class TrainingRepository : BaseRepository<Training, int>, ITrainingRepository
    {
        public TrainingRepository(NDDTrainingDbContext context) : base(context) { }

        // Obtem o primeiro treinamento com o nome inserido
        public Training GetByName(string name)
        {
            return _context.Trainings.FirstOrDefault(t => t.Title == name);
        }
        public bool VerifyExistingName(string title)
        {
            if (_context.Trainings.Any(x => x.Title == title))
            {
                return true;
            }
            return false;
        }
        public IList<Training> GetActiveTraining()
        {
            return _context.Trainings.Where(x => x.Active == true).ToList();
        }
        public IList<Training> GetSuspendedTraining()
        {
            return _context.Trainings.Where(x => x.Active == false).ToList();
        }      }

}