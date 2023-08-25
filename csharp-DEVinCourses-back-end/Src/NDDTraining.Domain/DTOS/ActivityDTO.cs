using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;

namespace NDDTraining.Domain.DTOS
{
    public class TrainingActivityDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

    }
}
