using EventManager.Application.Models.Speaker.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.Speaker;

public class SpeakerUpdateDtoValidator : AbstractValidator<SpeakerUpdateDto>
{
    public SpeakerUpdateDtoValidator(IValidator<SpeakerUpdateDto> speakerBaseDtoValidator)
    {
        RuleFor(s=>s).SetValidator(speakerBaseDtoValidator);
    }
}