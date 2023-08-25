using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Enums;
using NDDTraining.Domain.Exceptions;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Services
{

    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly ITrainingService _trainingService;
        private readonly IUserRepository _user;



        public RegistrationService(IRegistrationRepository registrationRepository, IEmailService emailService, ITrainingService trainingService,
            IUserRepository user
            )
        {
            _registrationRepository = registrationRepository;
            _emailService = emailService;
            _user = user;
            _trainingService = trainingService;
        }

        public IList<RegistrationDTO> GetAll()
        {
            return _registrationRepository.GetAll()
                  .Select(x => new RegistrationDTO(x)).ToList();

        }

        public void Insert(RegistrationDTO registration)
        {

          
            _registrationRepository.Insert(new Registration(registration));

            var training = _trainingService.GetById(registration.TrainingId);

            var user = _user.GetById(registration.UserId);

           

      
            SendEMail(training.Title, user, user.Name,user.Email, training.Description, training.Duration, training.Teacher, training.Url);
        }

        public void ValidateRegistration() { 

           
        }



        public void SendEMail(
             string nameCourse,
             User user,
             string name,
             string email,
             string description,
             TimeSpan duration,
             string teacher,
             string url
            
            )
        {
            _emailService.BuildAndSendMail(new Email()
            {
                To = user.Email,
                Subject = "Cadastramento no curso NDDTrainig",
                type = Enums.EmailType.Registration,
                Parameters = new Dictionary<string, string>()
            {
                {"training", nameCourse},
                {"email", email},
                 {"name", name },
                {"description", description},
                {"duration", duration.ToString() },
                {"teacher",teacher },
                {"url" , url}

            }
            });
        }

        public void ValidateRegistration(RegistrationDTO registration)

        {
            if (_registrationRepository.RegistrationDuplicate(registration.Id))
            {
                throw new DuplicateException("Registro ja existe na base de dados!");
            }

        }

        public void Delete(int id)
        {
            if (_registrationRepository.DeleteNoRegistration(id))
            {
                throw new DeleteNoRegistrationException("Não há arquivo para remoção.");
            }
            _registrationRepository.Delete(id);
        }

       public IList<RegistrationDTO> GetRegistrationsByUser(int userId, string status, Paging paging)
        {
            IEnumerable<Registration> trainingWithRegisters = _registrationRepository
                .GetRegistrationsByUser(userId, paging);

            if(trainingWithRegisters.Count() == 0)
                throw new NotFoundException("nenhum registro encontrado!");

            if(!String.IsNullOrEmpty(status))
            {
                var statusEnum = status.ConvertEnum<Status>();

                trainingWithRegisters = trainingWithRegisters
                    .Where(r => r.Status == statusEnum);
                
            }

            return trainingWithRegisters
                .Select(r => new RegistrationDTO(r)).ToList();
        }

        public IList<RegistrationDTO> GetRegistrationsByUserMostRecent(int userId)
        {
            IEnumerable<Registration> trainingWithRegisters = _registrationRepository
                    .GetRegistrationsByUserMostRecent(userId);

            return trainingWithRegisters
                .Select(r => new RegistrationDTO(r)).OrderByDescending(d => d.RefreshDate).ToList();
        }

        public void Patch(int id, long refreshDate)
        {
            _registrationRepository.Patch(id, refreshDate);
        }
  }

}
