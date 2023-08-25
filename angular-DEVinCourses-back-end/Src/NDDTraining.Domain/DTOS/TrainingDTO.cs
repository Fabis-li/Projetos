using System;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.DTOS
{
	public class TrainingDTO
	{
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Active { get; set; }
        public string Category { get; set; }

        public TrainingDTO()
		{
        }
        public TrainingDTO(Training training)
        {
            Id = training.Id;
            Url = training.Url;
            Title = training.Title;
            Description = training.Description;
            Teacher = training.Teacher;
            Duration = training.Duration;
            Active = training.Active;
            Category = training.Category;
        }
    }
}

