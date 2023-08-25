using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Models
{
    public class Module
    {
        public int Id { get; set; }
        public int? TrainingId { get; set; }
        public string TitleModule { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string DescriptionModule { get; set; }
        public string StatusModule { get; set; }

       //public virtual Training Training { get; set; }


        public Module()
        {
        }

        public Module(int id, int trainingId, string titleModule, string link, string image, string descriptionModule, string statusModule)
        {
            Id = id;
            TrainingId = trainingId;
            TitleModule = titleModule;
            Link = link;
            Image = image;
            DescriptionModule = descriptionModule;
            StatusModule = statusModule;
        }
    }
}
