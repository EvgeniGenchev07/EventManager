using EventManager.Application.Models.Event.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.Event;

public class EventBaseDtoValidator :  AbstractValidator<EventBaseDto>
{
    public EventBaseDtoValidator()
    {
        RuleFor(e=>e.Title)
            .NotNull().WithMessage("Title cannot be null")
            .NotEmpty().WithMessage("Title cannot be empty")
            .Length(5,50).WithMessage("Title must be 5 to 50 characters");
        RuleFor(e=>e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .NotEmpty().WithMessage("Description cannot be empty")
            .Length(20,150).WithMessage("Description must be 20 to 150 characters");
        RuleFor(e=>e.Location)
            .NotNull().WithMessage("Location cannot be null")
            .NotEmpty().WithMessage("Location cannot be empty")
            .Length(5,50).WithMessage("Location must be 5 to 50 characters");
        RuleFor(e=>e.Date)
            .NotNull().WithMessage("Date cannot be null")
            .NotEmpty().WithMessage("Date cannot be empty")
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the past");
    }
}