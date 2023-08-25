using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Exceptions
{
  public class DeleteNoRegistrationException : Exception
  {
    public DeleteNoRegistrationException(string message) : base(message)
    {

    }
  }
}