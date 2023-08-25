using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDDTraining.Domain.DTOS
{
    public class TrainingReportsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Active { get; set; }
        public int TotalUsersFinished { get; set; }
    }
}