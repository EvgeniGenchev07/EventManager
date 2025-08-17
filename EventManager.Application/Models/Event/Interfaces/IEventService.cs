using EventManager.Application.Models.Event.Dtos;

namespace  EventManager.Application.Models.Event.Interfaces;

public interface IEventService
{
    Task<EventGetDto> Get(int id);
    Task<IEnumerable<EventGetDto>> GetAll();
    Task<EventGetDto> Create(EventCreateDto dto);
    Task<EventGetDto> Update(EventUpdateDto dto);
    Task Delete(int id);
}