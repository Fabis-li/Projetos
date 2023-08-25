using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;
using NDDTraining.Domain.ViewModels;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface ITrainingService
    {
        public IList<TrainingDTO> GetAll(string category, Paging paging);
        public TrainingDTO GetById(int id);
        public TrainingDTO GetTrainingFinish();
        public TrainingDTO GetTrainingProgress();
        public void DeleteTraining();
        public void FinishTrainig();
        public void Suspend(string nameOrId);
        int Insert(TrainingDTO training);
        public IList<TrainingDTO> GetTrainingsByUser(int userId, Paging paging);
        public int ObterTotal();
        public Training GetByNameOrId(string nameOrId);
        public TrainingUsersDetails GetUsersDetails(string nameOrId);
        IList<TrainingReportsDTO> GetTrainingsReport(bool isActive);
    }
}
