using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Disponivel")]
        Disponivel,
        [Display(Name = "Andamento")]
        Andamento,
        [Display(Name = "Finalizado")]
        Finalizado,
    }
}
