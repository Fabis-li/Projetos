
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.DTOS
{
    public class UserDTO
    {
        public int? Id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public string Image { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(User user)
        {
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Age = user.Age;
            CPF = user.CPF;
            Image = user.Image;
        }

        public UserDTO(UserDTO user)
        {
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Age = user.Age;
            CPF = user.CPF;
            Image = user.Image;
        }

    }
}