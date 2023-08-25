using NDDTraining.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public Login(LoginDTO loginDTO)
        {
            Email = loginDTO.Email;
            Password = loginDTO.Password;
        }
    }
}
