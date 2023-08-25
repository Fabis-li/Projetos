
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Services
{

    public interface IRegistrationService
    {
        public IList<RegistrationDTO> GetAll();
        public IList<RegistrationDTO> GetRegistrationsByUserMostRecent(int userId);
        public IList<RegistrationDTO> GetRegistrationsByUser(int userId, string status, Paging paging);
        public void ValidateRegistration(RegistrationDTO registration);
        public void Insert(RegistrationDTO registration);
        public void Patch(int id, long refreshDate);
        public void Delete(int id);
       
  }
}
