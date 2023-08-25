using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface IEmailService
    {
       

        void BuildAndSendMail(Email email);
    }
}