using AutoMapper;
using EventManager.Application.Models.Event.Dtos;
using EventManager.Core.Entities;

namespace EventManager.Application.Profiles;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventGetDto>();
        CreateMap<EventCreateDto, Event>();
        CreateMap<EventUpdateDto, Event>();
    }
}