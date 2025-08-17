using EventManager.Application.Models.Speaker.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.Speaker;

public class SpeakerCreateDtoValidator : AbstractValidator<SpeakerCreateDto>
{
    public SpeakerCreateDtoValidator(IValidator<SpeakerBaseDto> speakerBaseDtoValidator)
    {
        RuleFor(s=>s.Email)
            .NotNull().WithMessage("Email is required")
            .NotEmpty().WithMessage("Email cannot be empty")
            .EmailAddress().WithMessage("Email must be a valid email address");
        RuleFor(s=>s).SetValidator(speakerBaseDtoValidator);
    }
}