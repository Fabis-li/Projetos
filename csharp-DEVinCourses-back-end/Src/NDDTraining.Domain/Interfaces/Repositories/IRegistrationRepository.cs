using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Repositories
{

    public interface IRegistrationRepository : IBaseRepository<Registration, int>
    {
        IList<Registration> GetAll();
        public void Delete(int id);
        bool RegistrationDuplicate(int id);
        public bool DeleteNoRegistration(int id);        
        IQueryable<Registration> GetRegistrationsByUser(int id, Paging paging);

        IQueryable<Registration> GetRegistrationsByUserMostRecent(int id /*Paging paging*/);

        public void Patch(int id, long refreshDate);

    }
}