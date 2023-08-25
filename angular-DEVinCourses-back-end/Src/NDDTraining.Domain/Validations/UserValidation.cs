
using FluentValidation;
using NDDTraining.Domain.DTOS;

namespace NDDTraining.Domain.Validations
{
    public class UserValidation : AbstractValidator<UserDTO>
    {
        public UserValidation()
        {
            RuleFor(x => x.Age)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")
                .GreaterThan(18)
                .WithMessage("idade não pode ser menor que 18");

            RuleFor(x => x.Email)
               .NotNull()
               .Length(3, 100).WithMessage("O Email deve ter no minimo 3 caracter e no maximo 100 !")
               .EmailAddress().WithMessage("Formato não esta aceito!");

            RuleFor(x => x.Password)
               .NotNull()
               .Length(8, 50).WithMessage("O Password deve ter no minimo 8 caracter e no maximo 50 !");


        }


    }
}
