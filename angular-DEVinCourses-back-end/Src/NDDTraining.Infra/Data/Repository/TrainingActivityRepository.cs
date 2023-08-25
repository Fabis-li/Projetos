using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;


namespace NDDTraining.Infra.Data.Repository
{
        public class TrainingActivityRepository : BaseRepository<TrainingActivity, int>, ITrainingActivityRepository
    {

            public TrainingActivityRepository(NDDTrainingDbContext context) : base(context)
            {
            }
        }
}
