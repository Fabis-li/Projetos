using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.DTOS
{
    public class ResetDTO
    {
        public string Token { get; set; }
        public string Password { get; set; }
        public ResetDTO(string token, string password)
        {
            Token = token;
            Password = password;
        }
    }
}
