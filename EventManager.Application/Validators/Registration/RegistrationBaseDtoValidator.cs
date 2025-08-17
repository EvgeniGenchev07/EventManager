using EventManager.Application.Models.Registration.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.Registration;

public class RegistrationBaseDtoValidator  : AbstractValidator<RegistrationBaseDto>
{
    public RegistrationBaseDtoValidator()
    {
        RuleFor(r=>r.Event).NotNull().WithMessage("Event cannot be null");
        RuleFor(r=>r.User).NotNull().WithMessage("User cannot be null");
    }
}