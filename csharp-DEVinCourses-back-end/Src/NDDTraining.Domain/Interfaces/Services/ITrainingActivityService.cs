using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface ITrainingActivityService
    {
        void Insert(TrainingActivityDTO activity);
        IList<TrainingActivity> GetAll();
        void Update(int id, string description);
    }
}
