using NDDTraining.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Models
{
    public class TrainingActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public TrainingActivity(TrainingActivityDTO activity)
        {
            Id = activity.Id;
            Title = activity.Title;
            Description = activity.Description;
        }
        public TrainingActivity(){}
    }


}
