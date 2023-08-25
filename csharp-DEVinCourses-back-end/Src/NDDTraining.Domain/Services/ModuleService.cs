using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ITrainingRepository _trainingRepository;

        public ModuleService(IModuleRepository moduleRepository, ITrainingRepository trainingRepository)
        {
            _moduleRepository = moduleRepository;
            _trainingRepository = trainingRepository;
        }

        public void FinishClassrom()
        {
            throw new NotImplementedException();
        }

        public void GetModule()
        {
            throw new NotImplementedException();
        }

        public List<ModuleDTO> GetByTraining(int trainingId)
        {

            var training = _trainingRepository.GetById(trainingId);
            if (training == null)
                throw new Exception("Register not found!");

            return _moduleRepository
            .GetByTraining(trainingId)
            .Select(x => new ModuleDTO(x))
            .ToList();
        }

        List<ModuleDTO> IModuleService.GetModule()
        {
            throw new NotImplementedException();
        }

        public void Insert(int idTraining, Training training)
        {
            //insere em cada módulo do curso o id e adciona ao banco de dados
            foreach (var module in training.Modules)
            {
                module.TrainingId = idTraining;
                _moduleRepository.Insert(module);
            }
        }
    }
}
