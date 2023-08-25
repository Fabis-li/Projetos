using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.DTOS
{
    public class ErrorDTO
    {
        public string Error { get; set; }

        public ErrorDTO(string error)
        {
            Error = error;
        }
    }
}
