using FluentValidation;
using StudentsApp.Models;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Address_Line)
            .NotEmpty().WithMessage("La dirección es obligatoria")
            .MaximumLength(200).WithMessage("Máx. 200 caracteres");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("La ciudad es obligatoria");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("El estado es obligatorio");

        RuleFor(a => a.Zip_Postcode)
            .NotEmpty().WithMessage("El código postal es obligatorio")
            .Matches(@"^\d{4,10}$").WithMessage("Debe tener entre 4 y 10 dígitos");
    }
}
