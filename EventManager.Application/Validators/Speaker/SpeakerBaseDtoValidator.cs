using EventManager.Application.Models.Speaker.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.Speaker;

public class SpeakerBaseDtoValidator : AbstractValidator<SpeakerBaseDto>
{
    public SpeakerBaseDtoValidator()
    {
        RuleFor(s=>s.Biography)
            .NotNull().WithMessage("Biography is required")
            .NotEmpty().WithMessage("Biography cannot be empty")
            .Length(20,150).WithMessage("Biography must be between 20 and 150 characters long");
        RuleFor(s=>s.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name cannot be empty")
            .Length(5,50).WithMessage("Name must be between 5 and 50 characters long");
    }
}