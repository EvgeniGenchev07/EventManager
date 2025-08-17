using EventManager.Application.Models.Event.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.Event;

public class EventCreateDtoValidator :  AbstractValidator<EventCreateDto>
{
    public EventCreateDtoValidator(IValidator<EventBaseDto> eventBaseDtoValidator)
    {
        RuleFor(e=>e).SetValidator(eventBaseDtoValidator);
    }
}