using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface IUserService
    {


        public bool validSize(string b64);
        User GetUser(string email);
        void InsertUser(UserDTO newUser);
        void Update(UserDTO changedUser, int id);
        String VerifyLogin (LoginDTO loginDTO);
        string Reset(string email);
        string VerifyToken(ResetDTO resetDTO);
        public bool InvalidSize(string b64);
    }
}
