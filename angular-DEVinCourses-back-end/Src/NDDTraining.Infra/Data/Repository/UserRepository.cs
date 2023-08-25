using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;

namespace NDDTraining.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(NDDTrainingDbContext context) : base(context) { }

        public User CheckUserByEmail (string email)
        {
            var checkedUser = _context.Users.FirstOrDefault(u => u.Email == email);
            return(checkedUser);
        }

        public User CheckUserByCPF (string cpf)
        {
            var checkedUser = _context.Users.FirstOrDefault(c => c.CPF == cpf);
            return(checkedUser);
        }

        public User VerifyLogin(Login login)
        {
            return _context.Users.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return (_context.Users.FirstOrDefault(u => u.Email == email)); ;
        }
        public User CheckResetEmail(string email)
        {
           return _context.Users.Where(u => u.Email == email).FirstOrDefault();  
        }

        public User GetAll()
        {
            return _context.Users.First();
           
        }
    }
}
