using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Models
{
  public class Paging
  {
    public Paging(int take, int skip)
    {
      Take = take;
      Skip = skip;
    }

    public int Take { get; set; }
    public int Skip { get; set; }
  }
}