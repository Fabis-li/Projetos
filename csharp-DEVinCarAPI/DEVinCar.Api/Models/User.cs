namespace DEVinCar.Api.Models
{
    public class User
    {
        public int Id {get; internal set;}
        public string Email { get; set; }
        public string Password { internal get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public User()
        {
            
        }
        public User(int id, string email, string password, string name, DateTime birthDate)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            BirthDate = birthDate;
        }
    }
}