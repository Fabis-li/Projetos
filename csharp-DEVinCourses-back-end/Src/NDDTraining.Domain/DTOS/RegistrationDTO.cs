using System;
using NDDTraining.Domain.Enums;
using NDDTraining.Domain.Models;


namespace NDDTraining.Domain.DTOS
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainingId { get; set; }
        public Status Status { get; set; }
        public long RefreshDate { get; set; }
        public Training Training { get; set; }
       


        public RegistrationDTO()
        {
        }

        public RegistrationDTO(Registration registration)
        {
            Id = registration.Id;
            UserId = registration.UserId;
            TrainingId = registration.TrainingId;
            Status = registration.Status;
            RefreshDate = registration.RefreshDate;
            Training = registration.Training;
        }

       
    }
}

