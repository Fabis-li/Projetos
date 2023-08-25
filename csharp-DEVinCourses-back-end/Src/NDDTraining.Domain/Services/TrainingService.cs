using System.Collections;
using System.Data;
using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;
using NDDTraining.Domain.Exceptions;
using NDDTraining.Domain.ViewModels;

namespace NDDTraining.Domain.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public TrainingService(ITrainingRepository trainingRepository, IUserRepository userRepository,
            IRegistrationRepository registrationRepository)
        {
            _trainingRepository = trainingRepository;
            _userRepository = userRepository;
            _registrationRepository = registrationRepository;
        }

        public void DeleteTraining()
        {
            throw new NotImplementedException();
        }

        public void FinishTrainig()
        {
            throw new NotImplementedException();
        }

        public IList<TrainingDTO> GetAll(string category, Paging paging)
        {
            var query = _trainingRepository.GetAll(paging).AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query = query.Where(t => t.Category.ToUpper() == category.ToUpper());

            if (!query.ToList().Any())
                throw new Exception("Register not found!");

            return query.Select(t => new TrainingDTO(t)).ToList();
        }

        public TrainingDTO GetById(int id)
        {
            var training = _trainingRepository.GetById(id);

            return new TrainingDTO(training);

        }


        public TrainingDTO GetTrainingFinish()
        {
            throw new NotImplementedException();
        }

        public TrainingDTO GetTrainingProgress()
        {
            throw new NotImplementedException();
        }

        // Função de suspensão de treinamento
        public void Suspend(string nameOrId)
        {

            // Obtem o treinamento pelo nome ou id
            Training training = GetByNameOrId(nameOrId);

            // Verifica se algum aluno está matriculado no treinamento
            if (_registrationRepository.GetAll().AsQueryable().Any(t => t.TrainingId == training.Id))
            {
                // O treinamento não pode ser suspenso se um aluno estiver matriculado nele, então é enviado um erro de bad request para o tratamento
                throw new BadRequestException("O treinamento não pode ser suspenso pois possui ao menos um aluno matriculado");
            }

            // Realizando a suspensão do treinamento que é equivalente a mudança de status do mesmo para false
            training.Active = false;
            _trainingRepository.Update(training);
        }
        public int Insert(TrainingDTO training)
        {
            //verifica se existe o nome que está sendo inserido no curso
            if (_trainingRepository.VerifyExistingName(training.Title))
            {
                throw new AlreadyExistsException($"Já existe um treinamento com o nome: {training.Title}");
            }

            //insere o curso no banco de dados
            _trainingRepository.Insert(new Training(training));

            //retorna o id do curso 
            var newTraining = _trainingRepository.GetByName(training.Title);
            return newTraining.Id;
        }

        public IList<TrainingDTO> GetTrainingsByUser(int userId, Paging paging)
        {
            var trainingWithRegisters = _registrationRepository.GetRegistrationsByUser(userId, paging);
            var trainingsByUser = trainingWithRegisters.Select(r => new TrainingDTO(r.Training)).ToList();

            return trainingsByUser;
        }

        // Função que procura treinamento pelo nome ou id inserido
        public Training GetByNameOrId(string nameOrId)
        {

            // Obtem o primeiro treinamento com o nome entregue na rota
            Training training = _trainingRepository.GetByName(nameOrId);

            // Verifica se o treinamento foi encontrado com o nome
            if (training == null)
            {

                // Tenta converter a variavel que contia o nome para um inteiro
                int id;
                if (Int32.TryParse(nameOrId, out id))
                {

                    // Se a conversão for possivel, obtem o primeiro treinamento com o id inserido na rota
                    training = _trainingRepository.GetById(id);

                    // Verifica se o treinamento foi encontrado com o id
                    if (training == null)
                    {
                        // Envia uma exceção pois o treinamento não foi encontrado
                        throw new BadRequestException("Treinamento não encontrado.");
                    }
                }
                else
                {
                    // Se a conversão para id não foi possível, retorna uma exceção que o treinamento não foi encontrado.
                    throw new BadRequestException("Treinamento não encontrado.");
                }
            }

            return training;
        }

        // Função que informa a quantidade de alunos cadastrados, concluintes e em curso do treinamento
        public TrainingUsersDetails GetUsersDetails(string nameOrId)
        {

            // Obtem o treinamento pelo nome ou id
            Training training = GetByNameOrId(nameOrId);

            // Obtem todas as matriculas feitas no treinamento
            IQueryable<Registration> registrations = _registrationRepository.GetAll()
                                                                            .AsQueryable()
                                                                            .Where(r => r.TrainingId == training.Id);

            // Cria algumas listas e variaveis que vão conter a quantidade de alunos registrados, em andamento e concluidos no treinamento
            IList<int> registred = new List<int>();
            int nRegistred = 0;
            IList<int> progress = new List<int>();
            int nProgress = 0;
            IList<int> finished = new List<int>();
            int nFinished = 0;

            // Passa pela lista de matriculas realizando algumas operações
            foreach (var item in registrations)
            {

                // Adiciona o id do aluno em questão na lista de matriculados e na contagem do mesmo
                nRegistred = nRegistred + 1;
                registred.Add(item.UserId);

                // Verifica se o status do treinamento para o aluno é 'em andamento'(Progress)
                if (item.Status == Enums.Status.Andamento)
                {

                    // Adiciona o id do aluno em questão na lista dos que estão em andamento do treinamento e na contagem do mesmo
                    nProgress = nProgress + 1;
                    progress.Add(item.UserId);
                }

                // Verifica se o status do treinamento para o aluno é 'concluido'(Finished)
                if (item.Status == Enums.Status.Finalizado)
                {

                    // Adiciona o id do aluno em questão na lista de concluidos e na contagem do mesmo
                    nFinished = nFinished + 1;
                    finished.Add(item.UserId);
                }
            }

            // Organiza os dados em uma view model para a entrega
            TrainingUsersDetails trainingUsersDetails = new TrainingUsersDetails
                (
                    training.Id,
                    registred,
                    nRegistred,
                    progress,
                    nProgress,
                    finished,
                    nFinished
                );

            return trainingUsersDetails;
        }
        public IList<TrainingReportsDTO> GetTrainingsReport(bool isActive)
        {
            //busca as matrículas e filtra pelas que estão com status de terminada
            var registrations = _registrationRepository.GetAll();
            var finishedRegistrations = registrations.Where(x => x.Status == Enums.Status.Finalizado).ToList();

            //busca a lista de cursos ativos ou suspensos
            IList<Training> trainings = new List<Training>();
            if (isActive)
            { trainings = _trainingRepository.GetActiveTraining(); }
            else { trainings = _trainingRepository.GetSuspendedTraining(); }

            //cria um dicionário de cursos moldado para o dto de relatório
            Dictionary<int, TrainingReportsDTO> dict = new();
            foreach (var item in trainings)
            {
                dict.Add(item.Id, new TrainingReportsDTO
                {
                    Id = item.Id,
                    Active = isActive,
                    Title = item.Title,
                    Duration = item.Duration,
                    TotalUsersFinished = 0
                });
            }

            //implementa o dicionário de relatórios com a quantidade de alunos que terminaram o curso
            foreach (var item in finishedRegistrations)
            {
                var report = dict.GetValueOrDefault(item.TrainingId);
                if (report != null)
                {
                    report.TotalUsersFinished++;
                }
            }
            var trainingsReports = dict.Select(x => x.Value).ToList();

            //coloca a lista de cursos em ordem decrescente 
            var descending = (IList<TrainingReportsDTO>)trainingsReports.OrderByDescending(x => x.TotalUsersFinished).ToList();
            return descending;
        }

        public int ObterTotal()
        {
            return _trainingRepository.ObterTotal();
        }
    }
}
