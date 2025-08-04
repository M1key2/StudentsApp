using FluentValidation;
using StudentsApp.Models;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(e => e.Mail)
            .NotEmpty().WithMessage("El email es obligatorio")
            .EmailAddress().WithMessage("Formato de email inválido");

        RuleFor(e => e.EmailType)
            .IsInEnum().WithMessage("El tipo de email es inválido");
    }
}
