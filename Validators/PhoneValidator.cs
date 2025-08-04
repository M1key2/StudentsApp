using FluentValidation;
using StudentsApp.Models; 

public class PhoneValidator : AbstractValidator<Phone>
{
    public PhoneValidator()
    {
        RuleFor(p => p.AreaCode)
            .NotEmpty().WithMessage("El código de área es obligatorio.")
            .Length(1, 5).WithMessage("El código de área debe tener entre 1 y 5 caracteres.");

        RuleFor(p => p.Phone_Number)
            .NotEmpty().WithMessage("El número de teléfono es obligatorio.")
            .Matches(@"^\d+$").WithMessage("El número debe contener solo dígitos.");
    }
}
