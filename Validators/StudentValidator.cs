using FluentValidation;
using StudentsApp.Models;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(s => s.First_Name)
            .NotEmpty().WithMessage("El nombre es obligatorio");

        RuleFor(s => s.Last_Name)
            .NotEmpty().WithMessage("El apellido es obligatorio");

        RuleForEach(s => s.Emails).SetValidator(new EmailValidator());
        RuleForEach(s => s.Phones).SetValidator(new PhoneValidator());
        RuleForEach(s => s.Addresses).SetValidator(new AddressValidator());
    }
}
