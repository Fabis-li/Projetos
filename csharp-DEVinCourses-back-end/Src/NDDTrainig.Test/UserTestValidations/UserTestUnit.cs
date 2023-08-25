using NUnit.Framework;
using FluentValidation.TestHelper;
using NDDTraining.Domain.Validations;
using NDDTraining.Domain.DTOS;

    [TestFixture]
    public class UserTestUnit
    {

        private UserValidation validator;
        [SetUp]
        public void Setup()
        {
            validator = new UserValidation();
        }

        [TestCase(32)]
        public void Validate_Age_in_userDto_Acept(int Age)
        {
            var Person = new UserDTO { Age = Age, Name = "RAUL" };
            var result = validator.TestValidate(Person);
            result.ShouldNotHaveValidationErrorFor(person => person.Age);
        }


        [TestCase(15)]
        public void Validate_Age_in_userDto_Not_Acept(int Age)
        {
            var Person = new UserDTO { Age = Age, Name = "RAUL" };
            var result = validator.TestValidate(Person);
            result.ShouldNotHaveValidationErrorFor(person => person.Age);

        }
        [TestCase("raulzito@gmail.com")]
        public void Validate_Email_in_userDto_Acept(string email){
            var Person = new UserDTO { Email = email, Name = "RAUL" };
            var result = validator.TestValidate(Person);
            result.ShouldNotHaveValidationErrorFor(person => person.Email);

        }

        [TestCase("raulzito")]
        public void Validate_Email_in_userDto_Not_Acept(string email)
        {
            var Person = new UserDTO { Email = email, Name = "RAUL" };
            var result = validator.TestValidate(Person);
            result.ShouldNotHaveValidationErrorFor(person => person.Email);

        }

        [TestCase("123fdo89x4jkd")]
        public void Validate_Password_in_userDto_Acept(string pass)
        {
            var Person = new UserDTO { Password = pass, Name = "RAUL" };
            var result = validator.TestValidate(Person);
            result.ShouldNotHaveValidationErrorFor(person => person.Password);

        }

        [TestCase("123fd")]
        public void Validate_Password_in_userDto_Not_Acept(string pass)
        {
            var Person = new UserDTO { Password = pass, Name = "RAUL" };
            var result = validator.TestValidate(Person);
            result.ShouldNotHaveValidationErrorFor(person => person.Password);

        }
    }
