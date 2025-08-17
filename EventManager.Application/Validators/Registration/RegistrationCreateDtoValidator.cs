using EventManager.Application.Models.Event.Dtos;
using EventManager.Application.Models.Registration.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.Registration;

public class RegistrationCreateDtoValidator :  AbstractValidator<RegistrationCreateDto>
{
    public RegistrationCreateDtoValidator(IValidator<RegistrationBaseDto> registrationBaseDtoValidator)
    {
        RuleFor(r=>r).SetValidator(registrationBaseDtoValidator);
    }
}