using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Exceptions
{
    public class NoDataException : Exception
    {
        public NoDataException(string message) : base(message)
        {
        }
    }
}
