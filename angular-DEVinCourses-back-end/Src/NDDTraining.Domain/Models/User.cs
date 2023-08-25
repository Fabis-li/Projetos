using NDDTraining.Domain.DTOS;

namespace NDDTraining.Domain.Models
{
    public class User
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public string Image { get; set; }
        public virtual List<Registration> Registrations { get; set; }
        public string ResetToken { get; set; }

        public User()
        {

        }

        public User (UserDTO userDTO)
        {
            Name = userDTO.Name;
            Email = userDTO.Email;
            Password = userDTO.Password;
            Age = userDTO.Age;
            CPF = userDTO.CPF;
            Image = userDTO.Image;
        }

        public User(int Id, string Name, string Email, string Password, int Age, string CPF)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Age = Age;
            this.CPF = CPF;
        }

    }
    
}