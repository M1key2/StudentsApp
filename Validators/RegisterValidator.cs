using FluentValidation;
using StudentsApp.DTOs;
namespace StudentsApp.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El usuario es obligatorio")
                .MinimumLength(3).WithMessage("El usuario debe tener al menos 3 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo es obligatorio")
                .EmailAddress().WithMessage("Formato de correo inválido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Las contraseñas no coinciden");
        }
    }
}